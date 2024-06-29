# gyongyosidavid-uninavigation

## Abstract

In recent years, the ubiquity of smartphones and the advancement in mobile and web application technologies have catalyzed innovative solutions for real-world problems. Among these, navigating vast and multifaceted environments such as university campuses poses a considerable challenge for students and visitors. This consolidated study underscores the development and implementation of an intuitive campus navigation application aimed at the University of Óbuda, intending to enhance the user experience in exploring the campus and accessing essential information seamlessly. The application capitalizes on the convergence of augmented reality (AR), wireless positioning algorithms, and an interactive mapping system, synergized across mobile and web platforms to foster a user-friendly interface.
The inception of this project was driven by a thorough analysis of the university navigation quandary, elucidating the expectsations and outlining the challenges therein. Following this, a high-level structural model of the application was crafted, laying a robust foundation for the deliberation on the selection of suitable technologies and frameworks. The core of the application hinges on a graphical user interface tailored for mobile devices, particularly focusing on pedestrian navigation. This interface is supplemented with AR views and a positioning algorithm predicated on wireless network signals to ascertain geographic locations within indoor settings, enriching the location-based services offered.
The implementation phase encountered documented challenges, each addressed with innovative solutions to ensure the robustness and usability of the application. A meticulously devised testing paradigm, encompassing unit testing, user testing, and rigorous AR functionality testing, was employed to evaluate the application's functionality, usability, and performance meticulously. The outcome of the tests underscored the application's capacity in simplifying campus navigation, enhancing information dissemination about buildings, services, and campus events, thereby contributing to fostering a sense of community.
Furthermore, the application presents an interactive map tailored to each facility's layout, facilitating users in exploring the campus, learning about buildings and services, and staying updated on campus events. The integration of web, mobile, and AR technologies has not only significantly improved the campus navigation experience but also hinted at a promising trajectory for further research and development in this realm.
In summation, this integrative study provides a comprehensive solution to the campus navigation challenge, amalgamating cutting-edge technologies and user-centered design principles. The resulting application embodies a substantial stride towards making campus exploration more accessible, informative, and engaging for the university community, showcasing a quintessential model of leveraging modern-day technologies to address real- world challenges.



## User manual
### Project set-up
#### Setup of SQL Server
In order to create the database, you need to use Docker. If it is not on the machine, it must be installed, and then the SQL Server container can be created with the following command, to which the backend project will be connected
```
docker run —name UniNavDb —env=MSSQL_SA_PASSWORD=UniNavDbPw123 —env=ACCEPT_EULA=Y -p 1433:1433 -d mcr.microsoft.com/azure-sql-edge
```

#### Backend set-up
The `uninavigation_backend.sln` solution file in the `uninavigation_backend` folder must be opened in Visual Studio. After that, the `Package Manager Console` must be opened (Tools > NuGet Package Manager > Package Manager Console). Enter the following command here:
```
Update-Database
```
If the dotnet cli is available on the system, this command can also be used to update the database with existing migrations:
```
dotnet ef database update
```
After that, the `uninavigation_backend` project can be run.
####  Setting up the Frontend
This requires [NodeJS](https://nodejs.org/en/download) to be pre-installed.
The `uninavigation_frontend` folder must be opened in Visual Studio Code or another code editor. Here the following must be issued as a Terminal command:
```
npm install
ng serve --port 4200
```
After that, it is available on localhost.
#### Mobile installation
This also requires [NodeJS](https://nodejs.org/en/download) to be pre-installed.
The `uninavigation_mobile` folder must be opened in Visual Studio Code or another code editor. Here the following must be issued as a Terminal command:
```
npm install
ng serve --port 8100
```
or
```
ionic serve --port 8100
```
After that, it is available on localhost.

### Default Admin user
By default, an admin user `superuser` is available, and the password required to enter is `Passw0rd!`. This user can be used to test all functions in the application.


## Summary

During the course of my thesis, I was introduced to several new technologies and development paradigms, among which the in-depth study of the MappedIn-inspired system stands out. Using the analogy of MappedIn, I took an in-depth look at indoor navigation solutions, with a particular focus on how these systems integrate geo-data into their services. In this context, I have also explored the development using the MappedIn API to integrate mapped data into the application, thus enhancing the user experience and interactivity.
In the context of this thesis, I have also analysed in detail the advantages of modern development environments such as ASP.NET, Angular and Ionic frameworks, which have enabled me to apply scalable and efficient solutions. And the use of AR (Augmented Reality) technology added interactive elements to the user interface, which also took real-time data integration and user interaction to a higher level.
During the system design, I paid particular attention to the detailed design process, which included defining the application's functions, roles, data tables and their relationships. This precise preparatory work allowed me to focus exclusively on coding during the development phase.
The application was tested manually and through automated endpoints that basically checked the correctness of the privilege management and data return. Throughout the project, I designed the development process in a step-by-step manner, moving from simpler tasks to more complex ones, ensuring an efficient and smooth development process.
Throughout the project, I learned a number of new methodologies and techniques, among which my problem-solving skills improved significantly thanks to the unexpected challenges I faced and how I successfully dealt with them. The experience and knowledge thus gained have contributed significantly to my professional development and the success of future projects.