# KiiSecAPI
link to a KiiSecWebMVC: https://github.com/rarxdxsirx/KiiSecWebMVC
Аксёнов Александр Константинович, группа ПР-311
БПОУ ОО «Омский авиационный колледж имени Н.Е.Жуковского»
Научный руководитель: Бабикова Татьяна Михайловна, преподаватель высшей категории
БПОУ ОО «Омский авиационный колледж имени Н.Е.Жуковского»

СИСТЕМА КОНТРОЛЯ ДОСТУПА К ФИЗИЧЕСКОМУ ОБЪЕКТУ

Данная работа выполнена студентом Аксёновым Александром Константиновичем как самостоятельная творческая работа вне рамок учебного процесса. Представлена система приложений по организации контроля физического доступа к значимому объекту, включающая в себя веб-сервис и мобильное приложение позволяющие предприятиям автоматизировать пропускной режим.
Ключевые слова: контроль доступа, КИИ, модуль, пропуск

Представленный комплект материалов содержит:
	Папку с файлами приложения;
	Презентацию выступления;
	Техническую документацию по работе с приложением;
	Демонстрационный ролик, показывающий работу приложения.

Используемые средства разработки: 
	SQL Server Management Studio, SQL;
	ASP .NET Core, AutoMapper, HTML, CSS, Visual Studio, C#;
	Android Studio, Java, jQuery, JavaScript;

Актуальность проекта: система позволяет организациям автоматизировать процессы контроля доступа к объекту. Система позволяет настроить её под структуру своего предприятия.
Цель проекта – разработать модуль, направленный на организацию пропускного режима.
Использование модуля позволяет:
	Руководителям предприятия создать профиль своей организации, создать аккаунты для своих сотрудников, управлять их правами, просматривать и управлять заявками на посещение;
	Работникам компании осуществлять различные действия с запросами на посещение объекта, в зависимости от их разрешений. Например, изменять статус заявки, назначать дату посещения, формально сверять данные.
	Обычным пользователям осуществлять запросы на личное или групповое посещение любой из доступных организаций и просматривать записи, сделанные ранее. После подачи заявки, гость получает числовой и QR коды своей записи.
При создании и изменения статуса запроса соответствующие пользователи получают об этом уведомление. 
Система имеет общую базу данных SQL Server Express с таблицей, которая содержит в себе информацию пользователях системы. Для хранения данных о учётных записях используется вторая таблица, в который хранятся логин, почта и хеш пароля.
Также существует Web API, созданное на платформе ASP.NET Core, к которому подключена БД, и используемое во всех приложениях. Архитектурный стиль интерфейса – REST и посылает ответы в формате JSON. Для разработки API использовался язык C#. 
Веб-сервис реализован в той же среде, что и API, основываясь на паттерне MVC (Model-view-controller). Помимо C# использовался язык гипертекстовой разметки HTML, а также язык стилей CSS и JavaScript. Для маппинга значений свойств объектов подключена библиотека AutoMapper.
Мобильное приложение спроектировано средствами среды Android Studio на языке программирования Java для разметки используется язык XML. Основная разница между созданием веб и мобильного приложений заключается в способе подключения и использования API. В мобильном приложении для этого используется библиотека Retrofit. Ссылка на скачивание мобильного приложения расположена на веб-сервисе.
Для обработки данных БД в каждом модуле создаются классы-модели, представляющие типы сущностей в БД
Пользователи модуля могут получить доступ к своему аккаунту с любого, наиболее удобного для него приложения, но считать QR-код возможно только с мобильного. 
Для контроля версиями используется распределенная система контроля версий Git, в качестве сервиса для Git используется GitHub.
На заключительном этапе созданное приложение было протестировано с учетом разработанных сценариев тестирования.
Практическая значимость работы заключается в возможности внедрения проекта для осуществления контроля доступа лиц к физическому объекту предприятия для его автоматизации, что ведёт к уменьшению затрат ресурсов компании и оптимизации самого процесса. 
В результате выполнения проекта был создан модуль «KiiSec».
Планируется дальнейшая разработка и улучшение системы, добавление нового функционала: возможность связи пользователей и представителей предприятий посредством текстовых сообщений, средство составления отчётов и его автоматическое формирование, черный список пользователей для организации и т.д., а также улучшение визуального оформления системы и её публикация в сеть.

СПИСОК ЛИТЕРАТУРЫ
1.	Документация по C# - https://learn.microsoft.com/ru-ru/dotnet/csharp/
2.	Документация по ASP.NET Core - https://learn.microsoft.com/ru-ru/aspnet/core/
3.	Документация по SQL Server - https://learn.microsoft.com/ru-ru/sql/
4.	Документация по Android Studio - https://developer.android.com/docs/
5.	Документация по WPF - https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/
6.	Руководство по C# - https://metanit.com/sharp/
7.	Руководство по Android Studio и Java - https://metanit.com/java/android/