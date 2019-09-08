using System;
using Atata;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowSample.steps
{
    [Binding]
    public class SignUpSteps
    {
        private IndexPage _indexPage;
        private MyAccountPage _myAccountPage;
        private SignUpPage _signUpPage;

        [AfterFeature()]
        public static void AfterFeature()
        {
            AtataContext.Current?.CleanUp();
        }

        [BeforeFeature()]
        public static void BeforeFeature()
        {
            // Find information about AtataContext set-up on https://atata.io/getting-started/#set-up
            AtataContext.Configure()
                        .UseChrome().
                        //    WithArguments("start-maximized").
                        UseBaseUrl("http://automationpractice.com/index.php")
                        .UseCulture("en-us")
                        .UseNUnitTestName()
                        .AddNUnitTestContextLogging().LogNUnitError().Build();
        }

        [Given(@"Joey is a new user")]
        public void GivenJoeyIsANewUser()
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"Joey is in the index page")]
        public void GivenJoeyIsInTheIndexPage()
        {
            _indexPage = Go.To<IndexPage>();
        }

        [Then(@"bring Joey to my account page")]
        public void ThenBringJoeyToMyAccountPage()
        {
            _myAccountPage.PageUrl.Should.Contain("my-account");
            Console.WriteLine();
        }

        [When(@"account information is")]
        public void WhenAccountInformationIs(Table table)
        {
            var accountInfo = table.CreateInstance<AccountInfo>();

            _signUpPage.AccountPane.FirstName.Set(accountInfo.FirstName)
                       .AccountPane.LastName.Set(accountInfo.LastName)
                       .AccountPane.Password.Set(accountInfo.Password);
        }

        [When(@"Joey sign up with email ""(.*)""")]
        public void WhenJoeySignUpWithEmail(string email)
        {
            var i = new Random(DateTime.Now.Ticks.GetHashCode()).Next(0, 10);
            var j = DateTime.Now.ToString("fff");
            _signUpPage = _indexPage.Login.ClickAndGo()
                                    .SignUp.Email.Set($"{i}{email}{j}")
                                    .SignUp.CreateAccount.ClickAndGo<SignUpPage>();
        }

        [When(@"receiver information is")]
        public void WhenReceiverInformationIs(Table table)
        {
            var addressInfo = table.CreateInstance<AddressInfo>();

            _myAccountPage = _signUpPage.AddressPane.FirstName.Set(addressInfo.FirstName)
                                        .AddressPane.LastName.Set(addressInfo.LastName)
                                        .AddressPane.Address1.SetRandom()
                                        .AddressPane.Address2.SetRandom()
                                        .AddressPane.City.Set(addressInfo.City)
                                        .AddressPane.Country.Set(addressInfo.Country)
                                        .AddressPane.State.Set(addressInfo.State)
                                        .AddressPane.ZipCode.Set(addressInfo.ZipCode)
                                        .AddressPane.MobilePhone.Set(addressInfo.MobilePhone)
                                        .Register.ClickAndGo<MyAccountPage>();
        }
    }
}

public class AddressInfo
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string MobilePhone { get; set; }
}

public class AccountInfo
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}