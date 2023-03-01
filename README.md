# TestPlatform


It is simple test platform to pass given tests and get your results.

<hr>
<h3>Program stack:</h3> 
<br>This project made on ASP.NET Core Web API + AngularTS. 
<br>Entity Framework Core used as ORM. Database provider is MsSQL server.
<br>For authentication/authorization it uses JWT.
<br>Also this project has auto migration. Built with Clean architecture approach.

<hr>
<h3>Project structure:</h3>

<a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Domain">Domain</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Domain/Entities">Entities</a><br>

<a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Application">Application</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Application/DTOs">DTOs</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Application/Helpers">Helpers</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Application/Interfaces">Interfaces</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Application/Interfaces/Data">Data</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Application/Interfaces/Service">Service</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Application/Mappers">Mappers</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Application/Services">Services</a><br>

<a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Infrastructure">Infrastructure</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Infrastructure/Persistence">Persistence</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Infrastructure/Persistence/Configurations">Configurations</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Infrastructure/Persistence/DataSeeding">DataSeeding</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.Infrastructure/Persistence/Repositories">Repositories</a><br>

<a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.WebAPI">WebAPI</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.WebAPI/Controllers">Controllers</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#x2022; <a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.WebAPI/Extensions">Extensions</a><br>

<a href="https://github.com/ASTR0-1/TestPlatform/tree/main/TestPlatform.WebUI">WebUI</a><br>
<hr>
<h3>Screenshots:</h3>
<b>Account Controller:</b><br>
![image](https://user-images.githubusercontent.com/71894616/222117021-a69f68ed-a780-446f-a451-8eaf1163ea5d.png)
<br>
<b>AnswerOption Controller:</b>
![image](https://user-images.githubusercontent.com/71894616/222117328-9ef72256-e5cb-4df4-ae91-4d6d7b6abcb6.png)
<br>
<b>Question Controller:</b>
![image](https://user-images.githubusercontent.com/71894616/222117357-15b92696-f044-4fe0-9ed8-803854f0f294.png)
<br>
<b>Test Controller:</b>
![image](https://user-images.githubusercontent.com/71894616/222117389-b5551449-6694-49f7-8ee2-c04c31cb10fe.png)
<br>
<b>UserTest Controller:</b>
![image](https://user-images.githubusercontent.com/71894616/222117417-8b8abfdd-6168-4137-9338-5a2761c503c7.png)

