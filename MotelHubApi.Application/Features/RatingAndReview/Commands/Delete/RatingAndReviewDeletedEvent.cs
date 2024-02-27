using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class RatingAndReviewDeletedEvent : BaseEvent
{
    public RatingAndReview RatingAndReview { get; set; }
    public RatingAndReviewDeletedEvent(RatingAndReview ratingAndReview)
    {
        this.RatingAndReview = ratingAndReview;
    }
}
