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

            //Update the Room Players Line and Bingo and Room message
            Room myRoom = db.Rooms.Find(myCard.Player.RoomId);
            myRoom.LinePlayer = Guid.Empty;
            myRoom.WinnerPlayer = Guid.Empty;
            myRoom.Message = $"{player.Name} joined the game";
            db.SaveChanges();   

            return View(myCard);
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
        public ActionResult EditRoom(Guid? id, Guid? roomId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = db.Players.Find(id);
            Room room = db.Rooms.Find(roomId);

            if (player == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (roomId == Guid.Empty) player.RoomId = Guid.Empty;
                else player.RoomId = roomId.Value;
            }

            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                if(player.RoomId==Guid.Empty) return RedirectToAction("PlayerCard", new { id = player.Id});
                return RedirectToAction("PlayerCard", new { id = player.Id});
            }
            return View(player);
        }
        [HttpPost]
        public ActionResult IsLine(Guid? roomId, Guid? playerId)
        {
            try
            {
                Room room = db.Rooms.Find(roomId);
                if (room.LinePlayer == Guid.Empty)
                {
                    //Update room msg
                    room.LinePlayer = playerId.Value;
                    room.Message = $"{db.Players.Find(playerId).Name} sang Line!";

                    //Increase player stads
                    Player player = db.Players.Find(playerId);
                    player.LineCount++;

                    //Update DB
                    db.SaveChanges();

                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                else
                {
                    //Other player already isLine
                    return new HttpStatusCodeResult(HttpStatusCode.Conflict);
                }                
            }
            catch (Exception)
            {
                //Player or Room not found
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            } 
        }

        [HttpPost]
        public ActionResult IsBingo(Guid? roomId, Guid? playerId)
        {
            try
            {
                Room room = db.Rooms.Find(roomId);
                if (room.WinnerPlayer == Guid.Empty)
                {
                    //Update room msg
                    room.WinnerPlayer = playerId.Value;
                    room.Message = $"{db.Players.Find(playerId).Name} sang BINGO!";

                    //Increase player stads
                    Player player = db.Players.Find(playerId);
                    player.BingoCount++;

                    //Update DB
                    db.SaveChanges();
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                else
                {
                    //Other player already isBingo
                    return new HttpStatusCodeResult(HttpStatusCode.Conflict);
                }

            }
            catch (Exception)
            {
                //Player or Room not found
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }
        }
        [HttpGet]
        public ActionResult GetMessageRoom (Player player)
        {           
            return PartialView("_RoomMsgPartial", player);
        }

        [HttpGet]
        public ActionResult CheckWinnerRoom(Guid playerRoomId)
        {
            bool output = false;            
            Room room = db.Rooms.Find(playerRoomId);
            if (room.WinnerPlayer != Guid.Empty)
            {
                output = true;
            }
            return Json(new { result = output }, JsonRequestBehavior.AllowGet);             
        }

        [HttpGet]
        public ActionResult GetWinnerRoom(Player player)
        {
            return PartialView("_WinnerMsgPartial", player);
        }
    }
}