Employee registry program. 
Functions of viewing the list of employees, adding new ones, deleting.

When you start the program, the initial screen opens, which should display:
- A table containing the current list of employees. Fields of the table - last name, first name, patronymic. Sorting in ascending order by "last name" field.
- Press the "Add" button to view the figure 2;
- Remove" button. 
Clicking the "Add" button opens the screen for adding new employees.
The screen contains:
- Fields for entering the information (last name, first name, patronymic);
- Press the "Save" button to save the data in the database. The user returns to the initial screen.
In order to delete an employee, you should select the necessary line on the initial screen with a mouse click and then press the "Delete" button.
If the deletion was successful, you must display a message about it in a pop-up window.
If the user tries to click the delete button without first selecting the employee, there should be an error information message.
Functioning requirements
- For the implementation of the application must be selected the programming language C#, the platform .Net Framework 4.5.
- The data layer must be implemented using MSSQL SERVER (at least 2005).
- Data access layer must be implemented using ORM Entity Framework technology (not lower than 6.0). The approach to generating the model is "Data-first".
- Data display layer must be implemented using Windows Presentation Foundation technology. 
