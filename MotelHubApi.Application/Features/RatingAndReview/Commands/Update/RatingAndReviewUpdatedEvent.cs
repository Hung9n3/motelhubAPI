using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class RatingAndReviewUpdatedEvent : BaseEvent
{
    public RatingAndReview RatingAndReview { get; set; }
    public RatingAndReviewUpdatedEvent(RatingAndReview ratingAndReview)
    {
        this.RatingAndReview = ratingAndReview;
    }
}
