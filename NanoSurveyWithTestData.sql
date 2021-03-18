create database NanoSurveyDb;
go

use NanoSurveyDb;

-- For inserting data, I removed the "identity" property from Id.

create table Results
(
	Id int not null,
	primary key (Id),
);

create table Interviews
(
	Id int not null,
	ResultId int not null,
	primary key(Id),
	foreign key (ResultId) references Results (Id)
);

create table Surveys
(
	Id int not null,
	Title nvarchar(100) not null,
	InterviewId int not null,
	primary key(Id),
	foreign key (InterviewId) references Interviews (Id)
);

create table Questions
(
	Id int not null,
	Title nvarchar(50) not null,
	SurveyId int not null,
	primary key(Id),
	foreign key (SurveyId) references Surveys (Id), 
);

create table Answers
(
	Id int not null,
	Text nvarchar(50) not null,
	QuestionId int not null,
	ResultId int
	primary key(Id),
	foreign key (QuestionId) references Questions (Id),
	foreign key (ResultId) references Results (Id),
);
go

create index IX_Interviews_ResultId on Interviews (ResultId);
create index IX_Surveys_Title on Surveys (Title);
create index IX_Surveys_InterviewId on Surveys (InterviewId);
create index IX_Questions_SurveyId on Questions (SurveyId);
create index IX_Answers_QuestionId on Answers (QuestionId);
go

insert into Results(Id)
values
(1);

insert into Interviews(Id, ResultId)
values
(1, 1);

insert into Surveys(Id, Title, InterviewId)
values
(1, N'Первый опрос', 1),
(2, N'Второй опрос', 1);

insert into Questions(Id, Title, SurveyId)
values
(1, N'Первый вопрос', 1),
(2, N'Второй вопрос', 1);

insert into Answers(Id, Text, QuestionId)
values
(1, N'Первый ответ', 1),
(2, N'Второй ответ', 1),
(3, N'Первый ответ', 2),
(4, N'Второй ответ', 2);