using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Constants;

namespace Tourism.ViewModels
{
    public partial class ArticleViewModel : BaseViewModel
    {
        public class Nav
        {
            public string type { get; set; }
        }

        public async override Task Initialize(object initData)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();

                var nav = initData as Nav;

                if (nav != null)
                    this.Data = nav;

                this.Article = await _article.GetArticle(this.Data.type);

                this.HtmlContent = $"<html><head><meta name='viewport' content='width=device-width,initial-scale=1,maximum-scale=1'/><style>html {{ background-color: {PageConstants.White}; color: {PageConstants.Black}; }} </style></head><body>{this.Article.AContent}</body></html>"; //$"<html><head><title>Xamarin Forms</title></head><body>{this.Article.AContent}</body></html>";

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await ErrorManager.DisplayErrorMessageAsync(ex, "Something went wrong! Please try again");
            }
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }


        protected async override void ViewIsDisappearing(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                await ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }
    }
}
