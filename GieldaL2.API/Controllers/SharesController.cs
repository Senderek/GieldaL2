using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GieldaL2.API.ViewModels.Edit;
using GieldaL2.API.ViewModels.View;
using GieldaL2.DB;
using GieldaL2.INFRASTRUCTURE.DTO;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace GieldaL2.API.Controllers
{
    /// <summary>
    /// Shares controller containing endpoints to manage user shares.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SharesController : ControllerBase
    {
		IShareService service;

		public SharesController(IShareService service)
		{
			this.service = service;
		}

        /// <summary>
        /// Retrieves a list of all shares.
        /// </summary>
        /// <returns>List of the all shares and backend statistics.</returns>
		[HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel<IEnumerable<ShareViewModel>>> Get()
		{
			var dto = new StatisticsDTO();
			var data = service.GetAllShares(dto).Select(p => Mapper.Map<ShareViewModel>(p)).ToList();

			var statistics = Mapper.Map<StatisticsViewModel<IEnumerable<ShareViewModel>>>(dto);
			statistics.Data = data;

			return statistics;
		}

        /// <summary>
        /// Retrieves share with the specified ID.
        /// </summary>
        /// <param name="id">ID of the requested share.</param>
        /// <returns>Share with the specified ID and backend statistics if success, otherwise 404 when not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel<ShareViewModel>> Get(int id)
		{
			var dto = new StatisticsDTO();
			var share = service.GetShareById(id, dto);

			if (share == null)
			{
				return NotFound(Mapper.Map<StatisticsViewModel>(dto));
			}

			var statistics = Mapper.Map<StatisticsViewModel<ShareViewModel>>(dto);
			statistics.Data = Mapper.Map<ShareViewModel>(share);

			return statistics;
		}

        /// <summary>
        /// Adds share offer passed in the request body.
        /// </summary>
        /// <param name="model">Share which will be added.</param>
        /// <returns>Backend statistics.</returns>
		[HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel> Post([FromBody] EditShareViewModel model)
		{
			var statisticsDto = new StatisticsDTO();
			service.AddShare(Mapper.Map<ShareDTO>(model), statisticsDto);

			Response.StatusCode = 201;
			return Mapper.Map<StatisticsViewModel>(statisticsDto);
		}

        /// <summary>
        /// Edits share with the specified ID.
        /// </summary>
        /// <param name="id">ID of the share which will be edited.</param>
        /// <param name="model">New data which will be applied to the share.</param>
        /// <returns>Backend statistics if share has been modified with success, otherwise 404 if not found.</returns>
		[HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel> Put(int id, [FromBody] EditShareViewModel model)
		{
			var dto = new StatisticsDTO();
			var share = service.GetShareById(id, dto);

			if (share == null)
			{
				return NotFound(Mapper.Map<StatisticsViewModel>(dto));
			}

			share = Mapper.Map<ShareDTO>(model);
			service.EditShare(id, share, dto);

			return Mapper.Map<StatisticsViewModel>(dto);
		}

        /// <summary>
        /// Deletes share with the specified ID.
        /// </summary>
        /// <param name="id">ID of the share which will be deleted.</param>
        /// <returns>Backend statistics if share has been deleted with success, otherwise 404 if not found.</returns>
		[HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
		public ActionResult<StatisticsViewModel> Delete(int id)
		{
			var dto = new StatisticsDTO();
			if (!service.DeleteShare(id, dto))
			{
				return NotFound(Mapper.Map<StatisticsViewModel>(dto));
			}

			return Mapper.Map<StatisticsViewModel>(dto);
		}
	}
}