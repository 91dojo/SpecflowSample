using Atata;

namespace SpecflowSample.steps
{
    using _ = SignUpPage;

    public class SignUpPage : Page<_>
    {
        public AddressPane AddressPane { get; set; }
        public AccountPane AccountPane { get; set; }
        [FindById("submitAccount")] public Button<_> Register { get; set; }
    }

    public class AddressPane : Control<_>
    {
        [FindById("firstname")] public TextInput<_> FirstName { get; set; }
        [FindById("lastname")] public TextInput<_> LastName { get; set; }
        [FindById("address1")] public TextInput<_> Address1 { get; set; }
        [FindById("address2")] public TextInput<_> Address2 { get; set; }
        [FindById] public TextInput<_> City { get; set; }

        [FindById("id_state", Visibility = Visibility.Hidden)]
        public Select<_> State { get; set; }

        [FindById("postcode")] public TextInput<_> ZipCode { get; set; }

        [FindById("id_country", Visibility = Visibility.Hidden)]
        public Select<_> Country { get; set; }

        [FindById("phone_mobile")] public TextInput<_> MobilePhone { get; set; }
    }

    public enum Country
    {
        UnitedStates = 21
    }

    public enum State
    {
        [Term("-")] None,
        Ohio,
        Hawaii,
        Texas
    }

    public class AccountPane : Control<_>
    {
        [FindById("customer_firstname")] public TextInput<_> FirstName { get; set; }
        [FindById("customer_lastname")] public TextInput<_> LastName { get; set; }
        [FindByName("passwd")] public PasswordInput<_> Password { get; set; }
    }
}