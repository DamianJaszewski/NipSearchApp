import React, { Component } from 'react';

const EntityPerson = ({ data, title }) => {
    return (
        <>
            <h4 id="entityPerson">{title}</h4>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Company Name</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Pesel</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(item => (
                        <tr key={item.nip}>
                            <td>{item.companyName}</td>
                            <td>{item.firstName}</td>
                            <td>{item.lastName}</td>
                            <td>{item.pesel}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
};

export default EntityPerson;
