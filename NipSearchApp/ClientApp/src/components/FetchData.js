import React, { Component } from 'react';
import EntityPerson from './EntityPerson'

const TableRow = ({ label, value }) => {
    return (
        <tr>
            <th>{label}</th>
            <td>{value}</td>
        </tr>
    );
};

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { companies: [], loading: true, inputValue: "" };
    }

    static renderCompaniesTable(company) {
        return (
            <>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <tbody>
                        <TableRow label={"Name"} value={company.name }/>
                        <TableRow label={"Nip"} value={company.nip}/>
                        <TableRow label={"Status Vat"} value={company.statusVat}/>
                        <TableRow label={"Regon"} value={company.regon }/>
                        <TableRow label={"Pesel"} value={company.pesel }/>
                        <TableRow label={"KRS"} value={company.krs }/>
                        <TableRow label={"Residence Address"} value={company.residenceAddress }/>
                        <TableRow label={"Working Address"} value={company.workingAddress }/>
                        <TableRow label={"Registration Legal Date"} value={company.registrationLegalDate }/>
                        <TableRow label={"Registration Denial Date"} value={company.registrationDenialDate }/>
                        <TableRow label={"Registration Denial Basis"} value={company.registrationDenialBasis }/>
                        <TableRow label={"Restoration Date"} value={company.restorationDate }/>
                        <TableRow label={"Restoration Basis"} value={company.restorationBasis }/>
                        <TableRow label={"Removal Date"} value={company.removalDate }/>
                        <TableRow label={"Removal Basis"} value={company.removalBasis }/>
                        <TableRow label={"HasVirtual Accounts"} value={company.hasVirtualAccounts }/>
                    </tbody>
                </table>
                <EntityPerson data={company.representatives} title={"Representatives"}/>
                <EntityPerson data={company.authorizedClerks} title={"Authorized Clerks"}/>
                <EntityPerson data={company.partners} title={"Partners"} />

                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Account Numbers</th>
                        </tr>
                    </thead>
                    <tbody>
                        {company.accountNumbers.map(item => (
                            <tr key={item.id}>
                                <td>{item.number}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>

            </>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderCompaniesTable(this.state.companies);

        return (
            <div>
                <h1 id="tabelLabel" >Company information</h1>
                <p>This component demonstrates fetching data from the server.</p>
                <input type="text" value={this.state.inputValue} onChange={this.handleInputChange} />
                <button onClick={this.handleFetchData}>Fetch Data</button>
                {contents}
            </div>
        );
    }

    handleInputChange = (event) => {
        this.setState({ inputValue: event.target.value });
    };

    handleFetchData = () => {
        const { inputValue } = this.state;
        this.populateCompanyData(inputValue);
    };

    async populateCompanyData(nip) {
        const response = await fetch(`search/${nip}`);
        const data = await response.json();
        this.setState({ companies: data, loading: false });
    }
}
