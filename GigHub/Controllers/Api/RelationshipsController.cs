using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    public class RelationshipsController : ApiController
    {
        private ApplicationDbContext _context;
        public RelationshipsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult FollowAnArtist(RelationshipDto dto)
        {
            var userId = User.Identity.GetUserId();
            var followee = _context.Users.SingleOrDefault(f => f.Id == dto.FolloweeId);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (followee == null)
            {
                return NotFound();
            }
            var relationship = new Relationship
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = userId
            };
            _context.Relationships.Add(relationship);
            _context.SaveChanges();
            return Ok();

        }

    }
}
