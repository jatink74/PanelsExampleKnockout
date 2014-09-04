using KnockoutPanelsExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KnockoutPanelsExample.Controllers
{
    public class PlayersController : ApiController {

        private PlayerContext db = new PlayerContext();

        public IHttpActionResult PostPlayers([FromBody] List<Player> model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            foreach (Player player in model) {
                if (player.Id == 0) {
                    db.Players.Add(player);
                }
                else {
                    db.Players.Attach(player);
                    db.Entry<Player>(player).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int id) {
            return db.Players.Count(e => e.Id == id) > 0;
        }
    }
}
