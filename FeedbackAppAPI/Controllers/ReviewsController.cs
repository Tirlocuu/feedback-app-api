using System.Collections.Generic;
using System.Web.Http;
using FeedbackAppAPI.Logic;
using FeedbackAppAPI.Models;

namespace FeedbackAppAPI.Controllers
{
    [Route("api/FeedbackAppAPI")]
    public class ReviewsController : ApiController
    {
        private readonly IReviewslogic _reviewslogic;
        public ReviewsController()
        {
            _reviewslogic = new ReviewsLogic();
        }

        [HttpGet]
        [Route("api/get/reviews")]
        public List<ReviewsModel> Get()
        {
            return _reviewslogic.GetReviews();
        }

        [HttpGet]
        [Route("api/get/review/{id:int}")]
        public ReviewsModel GetReview(int id)
        {
            return _reviewslogic.GetReview(id);
        }

        [HttpPost]
        [Route("api/post/review")]
        public void Post([FromBody] ReviewsModel model)
        {
            _reviewslogic.AddReview(model);
        }

        [HttpPut]
        [Route("api/edit/review")]
        public void Put([FromBody] ReviewsModel model)
        {
            _reviewslogic.EditReview(model);
        }

        [HttpDelete]
        [Route("api/delete/review/{id:int}")]
        public void Delete(int id)
        {
            _reviewslogic.DeleteReview(id);
        }
    }
}
