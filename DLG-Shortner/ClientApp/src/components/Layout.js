import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NotificationContainer } from 'react-notifications';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <Container>
          <NotificationContainer />
          {this.props.children}
        </Container>
      </div >
    );
  }
}
