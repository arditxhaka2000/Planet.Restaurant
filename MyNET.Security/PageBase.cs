using System;


namespace MyNET.Security.Web
{
	public class PageBase: System.Web.UI.Page
	{
		public PageBase()
		{
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.Load += new System.EventHandler(this.PageBase_Load);
		}

		private void PageBase_Load(object sender, System.EventArgs e)
		{
            if (Context.User.Identity.IsAuthenticated)
            {
                if (!(Context.User is SitePrincipal))
                {
                    // ASP.NET's regular forms authentication picked up our cookie, but we
                    // haven't replaced the default context user with our own. Let's do that
                    // now. We know that the previous context.user.identity.name is the e-mail
                    // AddWithValueress (because we forced it to be as such in the login.aspx page)				
                    SitePrincipal newUser = new SitePrincipal(Context.User.Identity.Name);
                    Context.User = newUser;
                }
            }
            else
                Response.Redirect("~/Default.aspx");
		}
	}
}
