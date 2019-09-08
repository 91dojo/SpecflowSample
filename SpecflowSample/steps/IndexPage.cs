using Atata;

namespace SpecflowSample.steps
{
    using _ = IndexPage;

    [Url("index.php")]
    public class IndexPage:Page<_>
    {
        [FindByContent("Sign in")]
        public LinkDelegate<LoginPage, _> Login { get; set; }
    }
}