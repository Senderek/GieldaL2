using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Services
{
    public class StockExchangeLogic : IStockExchangeLogic
    {
        private readonly ISellOfferService _sellOfferService;
        private readonly IBuyOfferService _buyOfferService;
        private readonly IUserService _userService;
        private readonly IShareService _shareService;
        private readonly IStockService _stockService;
        private readonly ITransactionService _transactionService;

        public StockExchangeLogic(
            ISellOfferService sellOfferService, 
            IBuyOfferService buyOfferService, 
            IUserService userService, 
            IShareService shareService, 
            IStockService stockService, 
            ITransactionService transactionService
            )
        {
            _sellOfferService = sellOfferService;
            _buyOfferService = buyOfferService;
            _userService = userService;
            _shareService = shareService;
            _stockService = stockService;
            _transactionService = transactionService;
        }

        public void FindSellOffers(BuyOfferDTO buyOffer, UserDTO currentUser, StatisticsDTO statistics)
        {

            if (currentUser.Value < buyOffer.Amount * buyOffer.Price)
            {
                return;
            }

            var offers = _sellOfferService.GetAll(statistics).Where(o => o.Price <= buyOffer.Price).OrderBy(o => o.Price);

            foreach (var offer in offers)
            {
                int tradedAmount;

                if (buyOffer.Amount < offer.Amount)
                {
                    var price = offer.Amount * offer.Price;

                    offer.Amount -= buyOffer.Amount;
                    tradedAmount = buyOffer.Amount;
                    var targetUser = _userService.GetUserById(offer.SellerId, statistics);

                    //money got exchanged
                    targetUser.Value += price;
                    currentUser.Value -= price;
                    currentUser.Password = null;
                    targetUser.Password = null;
                    _userService.EditUser(currentUser.Id, currentUser, statistics);
                    _userService.EditUser(targetUser.Id, targetUser, statistics);

                    //shares were taken from source
                    var targetedShare = _shareService.GetShareById(offer.ShareId, statistics);
                    targetedShare.Amount -= buyOffer.Amount;
                    _shareService.EditShare(targetedShare.Id, targetedShare, statistics);

                    //if current user has company share add them if not create entry for them
                    var currentUserShare = _shareService.GetAllShares(statistics).Where(c => c.OwnerId == currentUser.Id).Where(c => c.StockId == buyOffer.StockId).FirstOrDefault();
                    if (currentUserShare != null)
                    {
                        currentUserShare.Amount += buyOffer.Amount;
                        _shareService.EditShare(currentUserShare.Id, currentUserShare, statistics);
                    }
                    else
                    {
                        currentUserShare = new ShareDTO
                        {
                            OwnerId = currentUser.Id,
                            Amount = buyOffer.Amount,
                            StockId = buyOffer.StockId,
                        };
                        _shareService.AddShare(currentUserShare, statistics);
                    }

                    //Modify offer that we took shares from
                    _sellOfferService.Edit(offer, statistics);
                    buyOffer.Amount = 0;
                }
                else
                {
                    var price = offer.Amount * offer.Price;

                    buyOffer.Amount -= offer.Amount;
                    tradedAmount = offer.Amount;
                    var targetUser = _userService.GetUserById(offer.SellerId, statistics);

                    //money got exchanged
                    targetUser.Value += price;
                    currentUser.Value -= price;
                    currentUser.Password = null;
                    targetUser.Password = null;
                    _userService.EditUser(currentUser.Id, currentUser, statistics);
                    _userService.EditUser(targetUser.Id, targetUser, statistics);

                    //taking shares from seller offer
                    var targetedShare = _shareService.GetShareById(offer.ShareId, statistics);
                    targetedShare.Amount -= offer.Amount;
                    _shareService.EditShare(targetedShare.Id, targetedShare, statistics);

                    //giving shares to buyer
                    var currentUserShare = _shareService.GetAllShares(statistics).Where(c => c.OwnerId == currentUser.Id).Where(c => c.StockId == buyOffer.StockId).FirstOrDefault();
                    if (currentUserShare != null)
                    {
                        currentUserShare.Amount += buyOffer.Amount;
                        _shareService.EditShare(currentUserShare.Id, currentUserShare, statistics);
                    }
                    else
                    {
                        currentUserShare = new ShareDTO
                        {
                            OwnerId = currentUser.Id,
                            Amount = buyOffer.Amount,
                            StockId = buyOffer.StockId,
                        };
                        _shareService.AddShare(currentUserShare, statistics);
                    }

                    //deleting offer 
                    _sellOfferService.Delete(offer.Id, statistics);

                }

                TransactionDTO transaction = new TransactionDTO
                {
                    Amount = tradedAmount,
                    Price = offer.Price,
                    BuyerId = currentUser.Id,
                    SellerId = offer.SellerId,
                    StockId = buyOffer.StockId,
                    Date = DateTime.Now
                };
                _transactionService.Add(transaction, statistics);
            }

            if (buyOffer.Amount > 0)
            {
                buyOffer.BuyerId = currentUser.Id;
                _buyOfferService.Add(buyOffer, statistics);
                //freeze users money equivalent to amount of shares he wants to buy left after searching through the market
                currentUser.Value -= buyOffer.Amount * buyOffer.Price;
                currentUser.Password = null;
                _userService.EditUser(currentUser.Id, currentUser, statistics);
            }

            CalculatePriceChange(buyOffer.StockId, statistics);
        }

        public void FindBuyOffers(SellOfferDTO sellOffer, UserDTO currentUser, StatisticsDTO statistics)
        {

            //get all buy offers for stock specified in offer
            var share = _shareService.GetShareById(sellOffer.ShareId, statistics);
            var offers = _buyOfferService.GetAll(statistics)
                .Where(o=>o.StockId == share.StockId) //check if stock matched
                .Where(o => o.Price >= sellOffer.Price) //price greater or equeal one in created offer
                .Where(o=>o.BuyerId != currentUser.Id) //remove current user offers
                .OrderByDescending(o => o.Price); //order by most expensive - shares goes to a highest bidder

            foreach (var offer in offers)
            {
                int tradedAmount = 0;

                //after this case offer is empty and we don't add it to database
                if (sellOffer.Amount < offer.Amount)
                {
                    //sold some amount of shares to some user and subtract amount from this users offer
                    offer.Amount -= sellOffer.Amount;
                    _buyOfferService.Edit(offer, statistics);

                    //subtract those sold shares from current user share entry
                    share.Amount -= sellOffer.Amount;
                    _shareService.EditShare(share.Id, share, statistics);

                    //add sold shares to buyer share or create if doesn't have one
                    var buyerShare = _shareService.GetAllShares(statistics).Where(c => c.OwnerId == offer.BuyerId).FirstOrDefault();
                    if (buyerShare != null)
                    {
                        buyerShare.Amount += sellOffer.Amount;
                        _shareService.EditShare(buyerShare.Id, buyerShare, statistics);
                    }
                    else
                    {
                        buyerShare = new ShareDTO
                        {
                            OwnerId = currentUser.Id,
                            Amount = sellOffer.Amount,
                            StockId = offer.StockId,
                        };
                        _shareService.AddShare(buyerShare, statistics);
                    }

                    //give money to current user(share holder)
                    currentUser.Value += sellOffer.Amount * sellOffer.Price;
                    currentUser.Password = null;
                    _userService.EditUser(currentUser.Id, currentUser, statistics);

                    tradedAmount = sellOffer.Amount;
                    sellOffer.Amount = 0;
                }
                //this case implies that amount in created offer is greater than selected offer
                else
                {
                    sellOffer.Amount -= offer.Amount;

                    share.Amount -= offer.Amount;
                    _shareService.EditShare(share.Id, share, statistics);

                    currentUser.Value += offer.Amount * offer.Price;

                    _buyOfferService.Delete(offer.Id, statistics);

                }

                //adding transaction for each iteration of trading
                TransactionDTO transaction = new TransactionDTO
                {
                    Amount = tradedAmount,
                    Price = offer.Price,
                    BuyerId = offer.BuyerId,
                    SellerId = currentUser.Id,
                    StockId = offer.StockId,
                    Date = DateTime.Now
                };
                _transactionService.Add(transaction, statistics);
            }

            if (sellOffer.Amount > 0)
            {
                sellOffer.SellerId = currentUser.Id;
                _sellOfferService.Add(sellOffer, statistics);
                //freeze currentuser shares equivalent to amount left in offer
                share.Amount -= sellOffer.Amount;
                _shareService.EditShare(share.Id, share, statistics);
            }

            CalculatePriceChange(share.StockId, statistics);
        }

        public void CalculatePriceChange(int stockId, StatisticsDTO statistics)
        {
            decimal newPrice = _transactionService.GetAll(statistics).Where(item => item.StockId == stockId).TakeLast(100).Average(s => s.Price);
            StockDTO stock = _stockService.GetStockById(stockId, statistics);
            
            stock.PriceDelta = ((stock.CurrentPrice / newPrice) * 100) - 100;
            stock.CurrentPrice = newPrice;

            _stockService.EditStock(stockId, stock, statistics);

        }
 

    }
}
