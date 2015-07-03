#Linking Rabbit and Fox models: Web service based approach

DMIF is distributed model integration framework. It is going through iterative development and currently it is in prototype stage. One of the major challenges in integrating models is heterogeneity of hardware and software platforms of the participating models. To address this major challenge,  our approach is to  develop the framework using service-oriented architecture. In short, participating models are presented as Web services and the framework facilitates the communication between these Web service based models.
As a proof of concept of our approach and to investigate different model integration scenarios  we have implemented the classic Lotka-Volterra predator–prey model as two separate predator  and prey models. We call the predator model as Fox model and the prey model as Rabbit model. The Fox model is developed using Java and the Rabbit model is developed using C++. To present these models as Web services we have developed java Web service on top of the Fox model and C# based Web service for the Rabbit model.

Description of each folder is given below:
-	The foxws folder contains the source code of fox model which is developed as java class (named fox.java) and wrapper Web service (named foxws.java). The foxws can be run independently by using java IDEs like NetBeans or using web servers like GlassFish.
-	The rab_dll folder contains C++ project file created using QT. The purpose of this QT based project is to produce dll version of the rabbit model.
-	The rab_ws folder contains C# based Web service project. The Web service in this project folder is used to wrap the dll version of the rabbit model which is developed using c++.
-	The framework folder is the main file to run the model integration framework and it is developed as web application using C# ASP.NET.

To configure and utilize this framework follow the instructions given below:
-	Go to the folder named framework and open the file framework.sln using Microsoft Visual Studio. Before running the framework we should provide the url of the fox and rabbit Web services as web reference to the framework; which requires to run both Web services.
-	The two Web services can be deployed on same or different different machines. For example, we can deploy the fox_ws on Unix machine using  Apache web server, and rab_ws on windows machine using IIS web server. A number of step by step instruction on how to deploy Web services on web servers can be found on the internet. 
For example, how to deploy java Web service - https://blog.idrsolutions.com/2013/08/creating-and-deploying-a-java-web-service/ ; how to publish C# based Web service on iis - https://www.youtube.com/watch?v=enT8WGECBug 
-	However if deploying  Web services on web servers is challenging we can run fox_ws using NetBeans and rab_ws using Visual studio; and what we need is copy the urls and set it as web reference in the framework.
-	 To see the existing web references go to solution explorer-> project -> App_WebReferences, then you will find list of Web services which are configured to be accessed by the framework. To remove existing web references just select them and click remove. To set new references copy url of the Web service, right click  App_WebReferences and select ‘Add service References’.
-	After setting service references run the framework, go to ‘Integration’ menu and select ‘Fox-Rabbit’, you will find a web form to define simulation inputs.
-	To start the simulation provide appropriate inputs and click the run button. At the end of the simulation the output will be displayed as graphs and list of time-series data as show in dmif_3.png.
-	To save the output data click ‘Save Output’, it will store the data in Ms Access database named fmdb.accdb, specifically under tbloutput table. The table contains columns for time step of rabbit model, time steps of fox model, integration method used (i.e. Euler or Rune-Kutta), population of rabbit, and population of fox.

If you have any difficulty in using this framework feel free to contact getfeleke@gmail.com
