using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var followerId = User.Identity.GetUserId();

            var exists = _context.Followings.Any(f => f.FollowerId == followerId && f.FolloweeId == dto.FolloweeId);

            if (exists)
                return BadRequest("You are already following this artist.");

            var following = new Following
            {
                FollowerId = followerId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string followeeId)
        {
            var followerId = User.Identity.GetUserId();

            var following = _context.Followings.Single(f => f.FollowerId == followerId && f.FollowerId == followeeId);

            if (following == null)
                return BadRequest("Something is wrong.");

            _context.Followings.Remove(following);
            _context.SaveChanges();


            return Ok(followeeId);
        }
    }
}
