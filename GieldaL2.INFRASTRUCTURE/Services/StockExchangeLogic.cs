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

        public void ExecuteSellOffers(BuyOfferDTO buyOffer, UserDTO currentUser, StatisticsDTO statistics)
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
                _buyOfferService.Add(buyOffer, statistics);
            }
        }

        public void ExecuteBuyOffers(SellOfferDTO sellOffer, UserDTO currentUser, StatisticsDTO statistics)
        {
            
        }

    }
}
