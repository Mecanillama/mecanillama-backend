Feature: ReviewsServiceTests
As a User
I want to add new Review through API
In order to make it available for views.

    Background:
        Given the Endpoint https://localhost:7056/api/v1/reviews is available

    @review-adding
    Scenario: Add Review with Unique Comment
        When a Review Request is sent
          | Comment | Score |
          | Sample  | 1     |
        Then A Response with Status 200 is received
        And a Sample Resource is included in Response Body
          | Id | Comment | Score |
          | 1  | Sample  | 1     |

    @review-adding
    Scenario: Add Review with existing Title
        Given A Review is already stored
          | Id | Comment | Score |
          | 1  | Sample  | 1     |
        When a Review Request is sent
          | Comment | Score |
          | Sample  | 1     |
        Then A Response with Status 400 is received
        And An Error Message with value "Review already exists." is returned