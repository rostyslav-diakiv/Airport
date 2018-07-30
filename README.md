# Airport
HomeTask #11. BSA 2018. .Net stream

To be able to use Desktop client you should download the latest version of Web API project:

## Web API project
 - Download Airport WEB API project, branch: UWP-feature from:
 - https://github.com/rostyslav-diakiv/Airport/tree/UWP-feature
 - Use IIS as a web server, or if you want use Kestrel, change the configuration(url) of Desctop Client in: BaseService.cs

## Desktop client project
 - Желательно запускать на Винде обновленной до последней версии)

 ## Important about buttons above the lists of entities
 ### button: + (Create)
    - Creates empty entity localy in Collection
 ### button - (Delete)
    - Deletes selected Entity
 ### button [] (Save, Store, Edit)
    - If you selected already existing item and save changes you made it updates this entity
    - If you created empty entity in local collection, filled the empty from then it will create new Entity with your data

#11 Task Description

## UWP

Для написанного ранее API (Аэропорт) написать простой клиент, используя десктопную технологию UWP. Если кратко, то должен быть реализован весь функционал из предыдущего задания по Angular. Архитектура приложения мало чем отличается от клиента на Angular. Есть слой представления данных (Views), слой бизнес логики (Code behind (когда вы пишете обработчики событий в файлах .xaml.cs) или реализация MVVМ), и слой работы с сервером (Services). Для работы с сервером используйте уже знакомый HttpClient. Все действия пользователя должны быть асинхронными (используйте async/await).

## Что должно быть выполнено:

Сделать меню, которое позволяет перемещаться между коллекциями.
При переходе на пункт меню, приложение должно загружать коллекцию с сервера.
Для каждой коллекции написать страницу для вывода списка элементов с базовой информацией (информация зависит от конкретной коллекции, но необходимо разместить 1-2 основных поля в строке списка).
При нажатии на элемент списка, справа должен появится блок с детальной информацией об элементе списка.
В блоке с детальной информацией добавить возможность редактировать и удалять элементы.
Желательно попробовать responsive UI в UWP (если уменьшаем или увеличиваем размеры окна, элементы перестраиваются).
Если будет время и желание, то будет большим плюсом использование MVVM. ВАЖНО! Сначала напишите простой вариант (View - .xaml, и ее обработчики - .xaml.cs) для одной коллекции. Оцените свои силы, если получается легко - попробуйте добавить MVVM Light. Если не получается, не тратьте время, самое главное (будет достаточно для получения 10) - реализовать функционал любым способом.
