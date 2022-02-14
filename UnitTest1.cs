using eVotingSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_CountAllVotes()
        {
            // Test Data = TestCampaign and 5 Votes

            // arrange
            string campaign = "CampaignTest";
            int expected = 5;
            Auditor auditor = new Auditor();

            // act
            int votes = auditor.CountAllVotes(campaign);

            // assert
            Assert.AreEqual(expected, votes);
        }

        [TestMethod]
        public void TestMethod_CalculateWinner()
        {
            // arrange
            string campaign = "CampaignTest";
            string expected = "Ballot2";
            Auditor auditor = new Auditor();

            // act
            string winner = auditor.CalculateWinner(campaign);

            // assert
            Assert.AreEqual(expected, winner);
        }

        [TestMethod]
        public void TestMethod_Vote()
        {
            // Test Data = TestCampaign and 9 Votes (4 TestBallot2 and 5 TestBallot2)

            // arrange
            bool expected = true;

            int voteID = 0;
            string currentCampaign = "TestCampaignVote";
            string username = "userName";
            string password = "password";
            string ballotDesc = "Ballot1";

            Voter voter = new Voter();

            // act
            bool voteReturn = voter.Vote(voteID, currentCampaign, username, password, ballotDesc);

            // assert
            Assert.AreEqual(expected, voteReturn);
        }

        [TestMethod]
        public void TestMethod_CalculateOrder()
        {
            // Test Data = TestCampaign and 9 Votes (4 TestBallot2 and 5 TestBallot2)

            // arrange
            List<string> orderListExpected = new List<string>();
            orderListExpected.Add("Ballot2 - 3 Votes");
            orderListExpected.Add("Ballot3 - 2 Votes");

            string campaign = "CampaignTest";

            Auditor auditor = new Auditor();

            // act
            List<string> orderReturned = auditor.CalculateOrder(campaign);

            // assert
            int count = 0;
            foreach (string s in orderListExpected)
            {
                Assert.AreEqual(orderListExpected[count], orderReturned[count]);
                count++;
            }
        }

        [TestMethod]
        public void TestMethod_CreateUserAndVote()
        {
            // arrange
            bool expected = true;

            int voteID = 0;
            string currentCampaign = "TestCampaign2";
            string ballotDesc = "Ballot1";

            Voter voter = new Voter();
            Admin admin = new Admin();
            bool voteReturn = false;
            for (int i = 0; i < 5; i = i + 1)
            {
                //act
                admin.CreateUser(("TestUser" + i), "password", "Voter");
                voteReturn = voter.Vote(voteID, currentCampaign, ("TestUser" + i), "password", ballotDesc);

                // assert
                Assert.AreEqual(expected, voteReturn);
            }
        }
    }
}