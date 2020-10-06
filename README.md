# Чат
## Описание функционала:
Зарегистрированные пользователи могут обмениваться картинками и сообщениями.
Создавать приватные или общие беседы, просмотривать историю сообщений,
отправлять жалобу администратору на плохое поведение в чате собеседников.
Администратор имеет возможность заблокировать пользователя на 5 минут.
Заблокированный пользователь не может отправлять сообщения.
Приложение основано на asp.net mvc5, контроллерах web api,внедрении зависимостей NINJECKT,базе данных MS SQL,
JavaScript, Jquery,CSS и HTML.

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B3%D0%BB%D0%B0%D0%B2%D0%BD%D0%B0%D1%8F%20%D1%81%D1%82%D0%B0%D0%BD%D0%B8%D1%86%D0%B0.png)

## Регистрация пользователей
Для начала общения в чате, необходимо пройти процедуру регистрации:
![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D1%80%D0%B5%D0%B3%D0%B8%D1%81%D1%82%D1%80%D0%B0%D1%86%D0%B8%D1%8F%201.png)
![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D1%80%D0%B5%D0%B3%D0%B8%D1%81%D1%82%D1%80%D0%B0%D1%86%D0%B8%D1%8F%202.png)

Далее необходимо выполнить вход на сайт:
![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B2%D1%85%D0%BE%D0%B41.png)
![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B2%D1%85%D0%BE%D0%B42.png)

Далее открывается главная страница.
На главной странице отображается список зарегистрированных пользователей и список бесед,в которых состоит текущий пользователь.
В проекте применены анимированные кнопки действий пользователя.

## Создание беседы
 
При нажатии кнопки "Создать беседу" откроется окно добавления пользователей и названия беседы.

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B1%D0%B5%D1%81%D0%B5%D0%B4%D0%B0%202.png)

Новая беседа появится в списке бесед пользователя.

## Отправка сообщения в беседу
Для отправки сообщения в беседу, необходимо "кликнуть" название беседы, после чего откроется окно истории сообщений и отправки сообщений:

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%20%D0%B2%20%D0%B1%D0%B5%D1%81%D0%B5%D0%B4%D1%831.png)

прикрепление файла к сообщению:

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%BF%D1%80%D0%B8%D0%BA%D1%80%D0%B5%D0%BF%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5%20%D1%84%D0%B0%D0%B9%D0%BB%D0%B0.png)

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%20%D0%B2%20%D0%B1%D0%B5%D1%81%D0%B5%D0%B4%D1%832.png)

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D1%81%D0%BE%D0%BE%D0%B1%D1%89%D0%B5%D0%BD%20%D0%B2%20%D0%B1%D0%B5%D1%81%D0%B5%D0%B4%D1%833.png)


## Личные сообщения (быстрое создание беседы из 2-х человек)

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%BD%D0%B0%D0%BF%D0%B8%D1%81%D0%B0%D1%82%D1%8C1.png)

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%BD%D0%B0%D0%BF%D0%B8%D1%81%D0%B0%D1%82%D1%8C2.png)

## Жалоба на пользователя

Необходимо указать причину жалобы, после чего сообщение будет доставлено администратору:

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B6%D0%B0%D0%BB%D0%BE%D0%B1%D0%B0%201.png)

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B6%D0%B0%D0%BB%D0%BE%D0%B1%D0%B0%202.png)

## Админ-панель и блокировка пользователей

Пользователь,обладающий правами администратора имеет доступ к админ-панели:

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B0%D0%B4%D0%BC%D0%B8%D0%BD1.png)

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B0%D0%B4%D0%BC%D0%B8%D0%BD2.png)

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B0%D0%B4%D0%BC%D0%B8%D0%BD3.png)

Заблокированный пользователь не сможет отправлять сообщения в течении 5-ти минут:

![](https://github.com/E-A-Volobuev/ChatChat/blob/master/%D0%B1%D0%BB%D0%BE%D0%BA.png)
