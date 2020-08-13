# Hangfire Job Scheduling framework 

Hangfire

1. is a framework wrap all the bottom logic of implementing job scheduling including thread, timer etc and provides a flunt way to schedule jobs 
2. contains 3 components, client, server and storage
   
	client => used to send schedules 
	Server => run these schedules 
	storage => where the jobs are stored. It can be stored in memory or SQL server or other storage places. 
		