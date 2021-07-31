# Документация
Добро пожаловать в это руководство, я рад, что ты решил заглянуть сюда.

Данный проект был сделан ради того, что бы занять себя хоть чем то ;)

# Начало
И так, начнем!

Для создания билда нам необходимо:

1. Среда для работы с исходниками.
Лично я использую VS 2019/2022

Ссылки:

https://visualstudio.microsoft.com/ru/vs/preview/vs2022/

https://visualstudio.microsoft.com/ru/downloads/ (community)

2. Хостинг с установленной панелью. Инструкция по ее установке и т.д. https://youtu.be/K-tMGSVgk4A

3. Сами исходники. Для этого переходим в главный раздел, нажимаем "Code" -> "Download ZIP"

после чего мы их разархивируем в другую папку.

И так, в архиве мы видим папку "Sources", компилируем от туда проект "EncDecr"
после чего прогоняем в приложении ссылку на панель.

# Работа с основным билдом
Открываем проект ApolonSpaceXLoader, вставляем туда (Класс "Program.cs", строка dom) нашу ссылку из EncrDecr
и вновь компилируем.

Ура! На этом работа закончена! (Ну, или почти.)

# Использование консоли
Не знаю зачем, но я добавил данную функцию.

А почему бы и нет?

Для ее использования нам необходимо в панели найти вкладку "CMD Control",
и в соответствующем textBox ввести необходимую нам команду.

Уважаемый пользователь может спросить- "а что делать, если нам надо указать путь, а у 
машины нет диска "С"? ".

Не беда! На этот случай, я добавил получение пути с помощью конвертирования строки.

Пример использования в консоле:

`cd %AppData%\Apolon
cd %UserProfile%\Apolon
cd %Documents%\Apolon
cd %ProgramFiles%\Apolon
cd %Startup%\Apolon`


Пример использования в панели:

`cd {AppData}\Apolon
cd {UserProfile}\Apolon
cd {Documents}\Apolon
cd {ProgramFiles}\Apolon
cd {Startup}\Apolon`

Всё гораздо проще, чем кажется!

# Создание модулей и их использование
В проекте вы можете найти такой класс, как "MyModules.cs", который и позволяет нам использовать наши модули.

Важное примечание! 
1. Поддерживаются только модули написанные на C#
2. Имя класса должно быть "Class1"
3. Имя главного вызываемого метода "Start", без аргументов.
4. Другие методы вызываются через гл. метод "Start".
5. Если у вас установлен цикл, он должен выполняться в отдельном потоке.
6. В панели при добавлении модуля, параметр "Name" должен соответствовать имени проекта (модуля). Параметр link должен быть прямым, пример: <http://malwaregate.site/mymodule.dll>

Спасибо за внимание, надеюсь на фидбек!