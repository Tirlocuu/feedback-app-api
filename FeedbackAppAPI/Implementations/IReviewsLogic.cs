using FeedbackAppAPI.Models;
using System.Collections.Generic;

namespace FeedbackAppAPI.Logic
{
    interface IReviewslogic
    {
        List<ReviewsModel> GetReviews();
        ReviewsModel GetReview(int id);
        void AddReview(ReviewsModel model);
        void EditReview(ReviewsModel model);
        void DeleteReview(int id);
    }
}
