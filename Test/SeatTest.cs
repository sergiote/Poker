﻿using NUnit.Framework;
using Poker;
using System;

namespace Test
{
    [TestFixture]
    public class SeatTest
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(6)]
        [TestCase(8)]
        [TestCase(9)]
        public void Test_Generated_Seats_Are_Empty(int seatNumber)
        {
            Table table = new Table(9);
            Seat seat = table.Seats[seatNumber];

            bool isEmpty = seat.IsEmpty();

            Assert.AreEqual(isEmpty, true);
        }

        [Test]
        public void Test_Table_Has_Some_Empty_Seats()
        {
            Table table = new Table(5);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });

            var expected = table.Seats.IsAnyEmpty();

            Assert.AreEqual(expected, true);
        }

        [Test]
        public void Test_Table_Has_None_Empty_Seats()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });
            table.AddPlayer(new Player() { Name = "Player4" });

            bool expected = table.Seats.IsNoneEmpty();

            Assert.AreEqual(expected, true);
        }

        [Test]
        public void Test_Table_Has_No_Empty_Seats()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });
            table.AddPlayer(new Player() { Name = "Player4" });

           var exception = Assert.Throws<Exception>(() => table.AddPlayer(new Player() { Name = "Player5" }) );
           Assert.AreEqual(exception.Message, "Sorry, not empty seat found");
        }

        [Test]
        public void Test_Table_Already_Contains_Player()
        {
            Table table = new Table(4);
            var player = new Player() { Name = "Player" };
            table.AddPlayer(player);

           var exception = Assert.Throws<Exception>(() => table.AddPlayer(player));
           Assert.AreEqual(exception.Message, "Sorry, selected player is already playing");
        }


    }
}