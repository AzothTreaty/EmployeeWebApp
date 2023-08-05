Please run migration first before running as I added a few fields to accomodate the salary computation




QUESTION:
If we are going to deploy this on production, what do you think is the next
improvement that you will prioritize next? This can be a feature, a tech debt, or
an architectural design.


ANSWER:
If this will be deployed in production then i suggest to separate the front end with the backend. I'm not exactly familiar since I wasn't the one who set it up in my current company but I think it is better if this is created as a microservice and a microfrontend.

Cons: more setup time, possibly more servers/containers needed. 
Pros: backend devs wont encounter frontend issues whenever they try to run it locally and vice versa.




tech debts for this project:

1. Unit tests
2. Fluent Validations
3. actual computation and factory pattern

