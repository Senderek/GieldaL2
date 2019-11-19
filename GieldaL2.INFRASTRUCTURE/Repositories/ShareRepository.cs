using GieldaL2.DB;
using GieldaL2.DB.Entities;
using GieldaL2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Repositories
{
    public class ShareRepository : IShareRepository
    {
        /// <summary>
        /// Property that stores last  operation time on database
        /// </summary>
        public int LastOperationTime { get; set; }

        private readonly GieldaL2Context _context;

        public ShareRepository(GieldaL2Context context)
        {
            _context = context;            
        }

        /// <summary>
        /// Method that returns specific Share entity
        /// </summary>
        /// <param name="id">Identifier of Share</param>
        /// <returns>Singular Share entity</returns>
        public Share GetById(int id)
        {
            return _context.Shares.FirstOrDefault(share => share.Id == id);
        }

        /// <summary>
        /// Method that returns Collection of Share entities
        /// </summary>
        /// <returns>Collection of Share entities</returns>
        public ICollection<Share> GetAll()
        {
            return _context.Shares.ToList();
        }

        /// <summary>
        /// Method for adding Share entity to database
        /// </summary>
        /// <param name="share">Share entity to add</param>
        public void Add(Share share)
        {
            _context.Add(share);
            _context.SaveChanges();
        }

        /// <summary>
        /// Method for modifying Share entity
        /// </summary>
        /// <param name="share">Share entity to modify</param>
        public void Edit(Share share)
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Method for removing Share entity from database
        /// </summary>
        /// <param name="share">Share entity to remove</param>
        public void Remove(Share share)
        {
            _context.Remove(share);
            _context.SaveChanges();
        }
    }
}
