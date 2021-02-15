# FulEventProject
Пример базы данных (на стадии разработки)
  
  Человек: (для кранения всех данных связанным с конкретным человеком)
    Id
    Name
    Sername
    Patronym
    Modile
    Mail
    VK
    Comment

  Танцор: (всё для приложения и api)
    id
    PersonId
    Club
    GroupId
    Comment

  Группы организаторов: (для управления каким-либо ивентом: сампо, конкурс)
    Id
    Name
    Comment
  
  Классификация танцоров: (для хранения данных о каждом танцоре)
    Id
    DancerId
    SHAClasses
    Points
    IsCurrent
    Comment
  
  Старые ивенты: (для хранения прошедших ивентов)
    Id
    EventId
    DancerId
    JnJPointAdded
    ClassicPointAdded
    NextJnJClass
    NextClassicClass
    Comment

  Ивенты: (список всех ивентов)
    Id
    Name
    TypeId
    GroupId
    Location
    Price
    СategoryPrice
    Rules
    Comment

  Запланированные: (для планировки ближайших ивентов)
    Id
    EventId
    StartDate
    EndDate
    Comment

    
    
Таблицы константы АСХ

 Классы АСХ: 
  Id
  Name
  Direction
  TotalPoints
  Comment

Направления АСХ:
  Id
  Name
  Comment

Типы и вентов:
  Id
  Name
  Comment

