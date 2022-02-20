const fixturePath = 'trade-counterparty'

export function addTrade(interceptName)  {
    cy.fixture(fixturePath).then((fixture) => {
        cy.get(getIdButton('addTradeButton')).click();
        cy.get(getFormSelect('counterPartyId')).select(fixture.counterparty.name)
        cy.get(getFormInput('product')).type(fixture.trade.product)
        cy.get(getFormInput('quantity')).type(fixture.trade.quantity)
        cy.get(getFormInput('price')).type(fixture.trade.price)
        cy.get(getFormInput('date')).type(fixture.trade.date)
        cy.get(getFormInput('direction')).click()
        cy.get(getIdButton('submitButton')).click()
        cy.wait(interceptName).its('response.statusCode').should('equal', 201);
    })
}

export function addCounterparty(interceptName) {
    cy.fixture(fixturePath).then((fixture) => {
        cy.get(getIdButton('addCounterpartyButton')).click();
        cy.get(getFormInput('formControlName=name')).type(fixture.counterparty.name)
        cy.get(getIdButton('id=submitButton')).click()
        cy.wait(interceptName).its('response.statusCode').should('equal', 201);
    })
}

export function editTrade(interceptName) {
    cy.fixture(fixturePath).then((fixture) => {
        cy.get('table')
        .find('td')
        .contains(fixture.trade.product)
        .nextAll()
        .find('button')
        .contains('Edit')
        .click()
        cy.get(getFormSelect('counterPartyId')).select(fixture.trade.counterpartyId)
        cy.get(getFormInput('direction')).click()
        cy.get(getIdButton('submitButton')).click()
        cy.wait(interceptName).its('response.statusCode').should('equal', 200);
    })
}

export function removeTrade(interceptName){
    cy.fixture(fixturePath).then((fixture) => { 
        cy.get('table')
        .find('td')
        .contains(fixture.trade.product)
        .nextAll()
        .find('button')
        .contains('Remove')
        .click()
        cy.wait(interceptName).its('response.statusCode').should('equal', 204);
    })
}

export function selectTrade(interceptName) {
    cy.fixture(fixturePath).then((fixture) => { 
        cy.get('select[id=selectTrade]').select(fixture.counterparty.name)
        cy.get('td[id=counterpartyName]')
        .should('have.text', 'test')
        cy.wait(interceptName).its('response.statusCode').should('equal', 200);
    })
}

function getFormInput(formControlName) {
    return `input[formControlName=${formControlName}]`
}

function getIdButton(Id) {
    return `button[id=${Id}]`
}

function getFormSelect(formControlName) {
    return `select[formControlName=${formControlName}]`
}