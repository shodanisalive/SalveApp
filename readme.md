# SalveApp
### by *Marco Evangelisti*

This solution contains a base API constructed with an N-Tier architecture
There are no tests in the solution

When launching the application:
 * it will open the Swagger page where the controller methods can be tested
 * it will launch a Node console to load the Vue project which will, in turn, open a browser to show the clinics and their relative patients

Given more time:
 * I would have added proper unit and integration tests
 * Made an architecture that reads queues in Azure which contain files of patients and clinics which in turn would be parsed, depending on the format.
   This, in turn, would produce a CSV file that will be taken by another service that would just put the data in the Database (with unicity tests and producing a log about which records have been stored and which ones not and why)