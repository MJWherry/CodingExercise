# Notes

Record over class - The test is only for getting/querying. Plus, 

Endpoint post over get - querying usually you want to pass in a body for some complex query system. For this, it needs
to be post as get does not accept a body.

Logging - using built in ILogger but so can use serilog or nlog if wanting to. For now, will log to console
but would prefer to log to some type of database. should use a generic interceptor for all endpoints and log there

Exception handling - should wrap results to include api status codes and exceptions. Theres a difference between 
breaking and no responses, so if valid always return a result, if not it should return bad status code.