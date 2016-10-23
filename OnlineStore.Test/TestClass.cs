using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Test
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void GetUser()
        {
            #region Deneme
            //using (HttpClient client = new HttpClient())
            //{


            //    HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            //    var returnResult = await client.PostAsync("http://localhost:58764/api/service", content);
            //    var data = JsonConvert.SerializeObject(returnResult);
            //    result = bool.Parse(returnResult.Content.ReadAsStringAsync().Result);
            //    return result; 
            #endregion

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50970");
                HttpResponseMessage resp = client.GetAsync("http://localhost:50970/api/User/1").Result;
                var responseStatus = resp.StatusCode;
                Assert.AreEqual(responseStatus, "OK");
            }

        }
    }

    #region UnitTest Example
    //[TestMethod]
    //public void Withdraw_ValidAmount_ChangesBalance()
    //{
    //    // arrange
    //    double currentBalance = 10.0;
    //    double withdrawal = 1.0;
    //    double expected = 9.0;
    //    var account = new CheckingAccount("JohnDoe", currentBalance);
    //    // act
    //    account.Withdraw(withdrawal);
    //    double actual = account.Balance;
    //    // assert
    //    Assert.AreEqual(expected, actual);
    //} 
    #endregion
}


