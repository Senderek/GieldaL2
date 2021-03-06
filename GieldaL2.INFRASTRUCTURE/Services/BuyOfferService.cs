﻿using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Services
{
    public class BuyOfferService : IBuyOfferService
    {
        private readonly IBuyOfferRepository _buyOfferRepository;

        public BuyOfferService(IBuyOfferRepository buyOfferRepository)
        {
            _buyOfferRepository = buyOfferRepository;
        }

        public BuyOfferDTO GetById(int id, StatisticsDTO statistics)
        {
            var buyOffer = _buyOfferRepository.GetById(id);
            statistics.SelectsTime += _buyOfferRepository.LastOperationTime;
            statistics.SelectsCount++;

            if (buyOffer == null)
            {
                return null;
            }

            return Mapper.Map<BuyOfferDTO>(buyOffer);
        }

        public ICollection<BuyOfferDTO> GetByUserId(int userId, StatisticsDTO statistics)
        {
            var buyOffer = _buyOfferRepository.GetByUserId(userId).Select(s => Mapper.Map<BuyOfferDTO>(s)).ToList();
            statistics.SelectsTime += _buyOfferRepository.LastOperationTime;
            statistics.SelectsCount++;

            return buyOffer;
        }

        public ICollection<BuyOfferDTO> GetAll(StatisticsDTO statistics)
        {
            var buyOffer = _buyOfferRepository.GetAll().Select(s => Mapper.Map<BuyOfferDTO>(s)).ToList();
            statistics.SelectsTime += _buyOfferRepository.LastOperationTime;
            statistics.SelectsCount++;

            return buyOffer;
        }

        public void Add(BuyOfferDTO buyOffer, StatisticsDTO statistics)
        {
            _buyOfferRepository.Add(Mapper.Map<BuyOffer>(buyOffer));
            statistics.SelectsTime += _buyOfferRepository.LastOperationTime;
            statistics.SelectsCount++;
        }

        public bool Edit(BuyOfferDTO buyOffer, StatisticsDTO statistics)
        {
            var offer = _buyOfferRepository.GetById(buyOffer.Id);
            statistics.SelectsTime += _buyOfferRepository.LastOperationTime;
            statistics.SelectsCount++;

            if(offer == null)
            {
                return false;
            }

            offer.Price = buyOffer.Price;
            offer.Amount = buyOffer.Amount;

            _buyOfferRepository.Edit(offer);
            statistics.UpdatesTime += _buyOfferRepository.LastOperationTime;
            statistics.UpdatesCount++;
            return true;
        }

        public bool Delete(int id, StatisticsDTO statistics)
        {
            var buyOffer = _buyOfferRepository.GetById(id);
            if (buyOffer == null)
            {
                return false;
            }
            _buyOfferRepository.Remove(buyOffer);
            statistics.SelectsTime += _buyOfferRepository.LastOperationTime;
            statistics.SelectsCount++;
            return true;
        }
   
    }
}
