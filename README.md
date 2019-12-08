# DG.PhotoManagement.Api
Photo management Application

Web API when called:

Calls, combines and returns the results of:

o http://jsonplaceholder.typicode.com/photos
o http://jsonplaceholder.typicode.com/albums

Allows an integrator to filter on the user id – so just returns the albums and photos relevant
to a single user.

To get all Albums and their Photos call:

"api/albumsphotos"

To get all Albums and their Photos by UserId call:

"api/albumsphotos/user/1"