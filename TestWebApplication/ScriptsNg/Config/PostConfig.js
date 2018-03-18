app.config(function ($translateProvider) {
    $translateProvider.translations('en', {
        COUNTRY: 'Country',
        CITY: 'City',
        STREET: 'Street',
        HOMENUM: 'Home number',
        INDEX: 'Index',
        DATE: 'Date',
        SELECTLANG: 'Select language',
        DATACOUNT: 'Number of records in the table',
        APPLICATION: 'application',
        CURSERVER: 'Select current server'
    })
        .translations('ru', {
            COUNTRY: 'Страна',
            CITY: 'Город',
            STREET: 'Улица',
            HOMENUM: 'Номер дома',
            INDEX: 'Индекс',
            DATE: 'Дата',
            SELECTLANG: 'Выберите язык',
            DATACOUNT: 'Количество записей в таблице',
            APPLICATION: 'приложение',
            CURSERVER: 'Выбрать текущий сервер'
        });
    $translateProvider.preferredLanguage('ru');
    $translateProvider.useSanitizeValueStrategy('sanitizeParameters');
});