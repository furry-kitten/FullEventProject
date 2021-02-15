# FulEventProject
Пример базы данных (на стадии разработки)
  
#  Человек: 
    Id
    Name
    Sername
    Patronym
    Modile
    Mail
    VK
    Comment
    
  (для кранения всех данных связанным с конкретным человеком)

# Танцор:
    id
    PersonId
    Club
    GroupId
    Comment

  (всё для приложения и api)

# Группы организаторов:
    Id
    Name
    Comment

  (для управления каким-либо ивентом: сампо, конкурс)
  
# Классификация танцоров:
    Id
    DancerId
    SHAClasses
    Points
    IsCurrent
    Comment

  (для хранения данных о каждом танцоре)
  
# Старые ивенты:
    Id
    EventId
    DancerId
    JnJPointAdded
    ClassicPointAdded
    NextJnJClass
    NextClassicClass
    Comment

  (для хранения прошедших ивентов)

# Ивенты:
    Id
    Name
    TypeId
    GroupId
    Location
    Price
    СategoryPrice
    Rules
    Comment

  (список всех ивентов)

# Запланированные:
    Id
    EventId
    StartDate
    EndDate
    Comment

  (для планировки ближайших ивентов)

    
    
# Таблицы константы АСХ

# Классы АСХ: 
    Id
    Name
    Direction
    TotalPoints
    Comment

# Направления АСХ:
    Id
    Name
    Comment

# Типы и вентов:
    Id
    Name
    Comment

