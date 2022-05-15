
function createTodoItem(todoListId, todoListTitle) {
    $.post(
        '/TodoItem/Create',
        {
            fields: {
                todoListId: todoListId,
                todoListTitle: todoListTitle,
                title: document.getElementById('Title').value,
                responsiblePartyId: document.getElementById('ResponsiblePartyId').value,
                importance: document.getElementById('Importance').value,
                rank: document.getElementById('Rank').value
            }
        })
        .done(() => window.location.href = `/TodoList/Detail?todoListId=${todoListId}`)
        .fail(error => {
            if (error.status === 400) {
                let errorMessage = JSON.parse(error.responseText).map(e => `- ${e}`).join('\n')
                alert(errorMessage);
            } else {
                alert('unexpected error')
            }
        })

    return false;
}