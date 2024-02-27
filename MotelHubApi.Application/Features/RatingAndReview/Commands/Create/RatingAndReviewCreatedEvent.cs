using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class RatingAndReviewCreatedEvent : BaseEvent
{
    public RatingAndReview RatingAndReview { get; set; }
    public RatingAndReviewCreatedEvent(RatingAndReview ratingAndReview)
    {
        this.RatingAndReview = ratingAndReview;
    }
}
