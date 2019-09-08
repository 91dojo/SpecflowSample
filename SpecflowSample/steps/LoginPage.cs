using Atata;

namespace SpecflowSample.steps
{
    using _ = LoginPage;

    public class LoginPage : Page<LoginPage>
    {
        public SignUpPane SignUp { get; set; }

        public class SignUpPane : Control<_>
        {
            [FindByName("email_create")]
            public TextInput<_> Email { get; set; }

            [FindById("SubmitCreate")]
            public Button<_> CreateAccount { get; set; }
        }
    }
}