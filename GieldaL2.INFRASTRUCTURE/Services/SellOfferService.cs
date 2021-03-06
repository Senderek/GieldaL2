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
    public class SellOfferService : ISellOfferService
    {
        private readonly ISellOfferRepository _sellOfferRepository;

        public SellOfferService(ISellOfferRepository sellOfferRepository)
        {
            _sellOfferRepository = sellOfferRepository;
        }

        public SellOfferDTO GetById(int id, StatisticsDTO statistics)
        {
            var sellOffer = _sellOfferRepository.GetById(id);
            statistics.SelectsTime += _sellOfferRepository.LastOperationTime;
            statistics.SelectsCount++;

            if (sellOffer == null)
            {
                return null;
            }

            return Mapper.Map<SellOfferDTO>(sellOffer);
        }

        public ICollection<SellOfferDTO> GetByUserId(int userId, StatisticsDTO statistics)
        {
            var buyOffer = _sellOfferRepository.GetByUserId(userId).Select(s => Mapper.Map<SellOfferDTO>(s)).ToList();
            statistics.SelectsTime += _sellOfferRepository.LastOperationTime;
            statistics.SelectsCount++;

            return buyOffer;
        }

        public ICollection<SellOfferDTO> GetAll(StatisticsDTO statistics)
        {
            var sellOffer = _sellOfferRepository.GetAll().Select(s => Mapper.Map<SellOfferDTO>(s)).ToList();
            statistics.SelectsTime += _sellOfferRepository.LastOperationTime;
            statistics.SelectsCount++;

            return sellOffer;
        }

        public void Add(SellOfferDTO sellOffer, StatisticsDTO statistics)
        {
            _sellOfferRepository.Add(Mapper.Map<SellOffer>(sellOffer));
            statistics.SelectsTime += _sellOfferRepository.LastOperationTime;
            statistics.SelectsCount++;
        }

        public bool Edit(SellOfferDTO sellOffer, StatisticsDTO statistics)
        {
            var offer = _sellOfferRepository.GetById(sellOffer.Id);
            statistics.SelectsTime += _sellOfferRepository.LastOperationTime;
            statistics.SelectsCount++;

            if (offer == null)
            {
                return false;
            }

            offer.Price = sellOffer.Price;
            offer.Amount = sellOffer.Amount;

            _sellOfferRepository.Edit(offer);
            statistics.UpdatesTime += _sellOfferRepository.LastOperationTime;
            statistics.UpdatesCount++;
            return true;
        }
          
        public bool Delete(int id, StatisticsDTO statistics)
        {
            var sellOffer = _sellOfferRepository.GetById(id);
            if (sellOffer == null)
            {
                return false;
            }
            _sellOfferRepository.Remove(sellOffer);
            statistics.SelectsTime += _sellOfferRepository.LastOperationTime;
            statistics.SelectsCount++;
            return true;
        }
    }
}
