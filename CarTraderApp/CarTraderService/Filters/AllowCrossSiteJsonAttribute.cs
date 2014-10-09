//namespace CarTraderService.Filters
//{
//    using System.Web.Http.Filters;
    
//    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
//    {
//        /// <summary>
//        /// The origin Uri to accept requests from
//        /// </summary>
//        private string origin;

//        /// <summary>
//        /// Initialises a new instance of the <see cref="AllowCrossSiteJsonAttribute"/> class
//        /// </summary>
//        /// <param name="origin">The origin URI to accept</param>
//        public AllowCrossSiteJsonAttribute(string origin)
//        {
//            this.origin = origin;
//        }

//        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
//        {
//            if (actionExecutedContext.Response != null)
//                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", this.origin);

//            base.OnActionExecuted(actionExecutedContext);
//        }
//    }
//}