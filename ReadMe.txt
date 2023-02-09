Web Api Built with .Net Core 6.0.0 Using DDD, hexagonal architecture, CRQS

WebApi Structure
	Api
	Core 
		Application
		Domain
	Infrastructure
	UnitTesing
	
Credentials

	USER				PASSWORD			PROFILE
	developer			1234				Admin	
	escritor			1234				Writer
	supervisor			1234				Editor	
	publico				1234				Public


Swageer - authorize

Controller			Admin	Editor Writer	Public
Author	
Get					x		x		x		x
Post				x
Put					x
Delete				x

Post
Get					x		x		x		x
Post				x				x
Approve				x		x		x
Put					x		x
Delete				x				x

Comment
Get					x		x		x		x
Post				x		x		x		x
Put					x		x		x		x
Delete				x		x		x		x