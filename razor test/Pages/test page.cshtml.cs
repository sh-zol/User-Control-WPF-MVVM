using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_test.Pages
{
    public class test_pageModel : PageModel
    {
            [BindProperty]
            public string Name { get; set; }
            [BindProperty]
            public int Age { get; set; }
            public string GettingMassage {  get; set; }
        
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (string.IsNullOrEmpty(Name))
            {
                GettingMassage = "enter your name";
            }

            else if (Age <= 0)
            {
                GettingMassage = "enter your age";
            }

            else
            {
                GettingMassage = $"hi {Name} you're {Age} years old";
            }
        }
    }
}
