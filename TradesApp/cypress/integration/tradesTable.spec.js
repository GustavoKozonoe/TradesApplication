import { addCounterparty, addTrade, editTrade, removeTrade, selectTrade } from "./functions";

describe('Trade Table', () => {
    beforeEach(function () {
        cy.intercept('POST', 'https://localhost:7158/api/Trades').as('submitTrade');
        cy.intercept('PUT', 'https://localhost:7158/api/Trades').as('editTrade');
        cy.intercept('DELETE', /https:\/\/localhost:7158\/api\/Trades\/[0-9]+$/).as('removeTrade');
        cy.intercept('POST', 'https://localhost:7158/api/CounterParties').as('submitCounterparty');
        cy.intercept(/https:\/\/localhost:7158\/api\/Trades\/getByCounterpartyId\/[0-9]+$/).as('selectCounterparty');

        cy.visit("http://localhost:4200/trades-table");
    });

    it.skip('add counterparty', () => {
        addCounterparty('@submitCounterparty')
    });

    it.skip('add trade', () => {
       addTrade('@submitTrade')
    });

    it.skip('Edit Trade', () => {
        editTrade('@editTrade')
    });

    it.skip('Remove Trade ?', () => {
        removeTrade('@removeTrade')
    });

    it('select Counterparty', () => {
        selectTrade('@selectCounterparty')
    });
});