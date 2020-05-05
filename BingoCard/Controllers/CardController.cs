﻿using BingoCard.DataAccess;
using BingoCard.Helpers;
using BingoCard.Models;
using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace BingoCard.Controllers
{
    public class CardController : Controller
    {
        private BingoCardDBContext db = new BingoCardDBContext();      

        // GET: Card  
        public ActionResult Index()
        {
            return View(CardHelper.CreateCard());
        }

        // GET: Card  Id Player
        public ActionResult PlayerCard(Guid? id)
        {
            //Verify player
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            //Return an object Card
            Card myCard = CardHelper.CreateCard();

            //Add the player Id
            myCard.Player = player;           

            return View(myCard);
        }
        [HttpPost]
        public ActionResult PostCard(Card card)
        {
            return Json(new { url = "URL" });
        }

        public ActionResult RoomSelection(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditRoom([Bind(Include = "Id,Name,BingoCount,LineCount,AvatarID,IsEnabled,RoomName")] Player player)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(player).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(player);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditRoom(Guid? id, string roomName)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            else
            {
                player.RoomName = roomName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                if(!string.IsNullOrEmpty(player.RoomName)) return RedirectToAction("PlayerCard", new { id = player.Id});
                return RedirectToAction("RoomSelection");
            }
            return View(player);
        }
    }
}