create database NanoSurveyDb;
go

use NanoSurveyDb;

create table Results
(
	Id int not null identity,
	primary key (Id),
);

create table Interviews
(
	Id int not null identity,
	ResultId int not null,
	primary key(Id),
	foreign key (ResultId) references Results (Id)
);

create table Surveys
(
	Id int not null identity,
	Title nvarchar(100) not null,
	InterviewId int not null,
	primary key(Id),
	foreign key (InterviewId) references Interviews (Id)
);

create table Questions
(
	Id int not null identity,
	Title nvarchar(50) not null,
	SurveyId int not null,
	primary key(Id),
	foreign key (SurveyId) references Surveys (Id), 
);

create table Answers
(
	Id int not null identity,
	Text nvarchar(50) not null,
	QuestionId int not null,
	primary key(Id),
	foreign key (QuestionId) references Questions (Id),
);

alter table Results
add QuestionId int;

alter table Results
add foreign key (QuestionId) references Questions (Id);

alter table Results
add AnswerId int;

alter table Results
add foreign key (AnswerId) references Answers (Id);

go

create index IX_Interviews_ResultId on Interviews (ResultId);
create index IX_Surveys_Title on Surveys (Title);
create index IX_Surveys_InterviewId on Surveys (InterviewId);
create index IX_Questions_SurveyId on Questions (SurveyId);
create index IX_Answers_QuestionId on Answers (QuestionId);
create index IX_Results_QuestionId on Results (QuestionId);
create index IX_Results_AnswerId on Results (AnswerId);
go

insert into Results default values;

insert into Interviews(ResultId)
values
(1);

insert into Surveys(Title, InterviewId)
values
(N'Первый опрос', 1),
(N'Второй опрос', 1);

insert into Questions(Title, SurveyId)
values
(N'Первый вопрос', 1),
(N'Второй вопрос', 1);

insert into Answers(Text, QuestionId)
values
(N'Первый ответ', 1),
(N'Второй ответ', 1),
(N'Первый ответ', 2),
(N'Второй ответ', 2);