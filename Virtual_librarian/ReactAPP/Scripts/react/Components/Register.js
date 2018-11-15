import React from "react";

import {
    Container, Col, Form,
    FormGroup, Label, Input,
    Button,
} from 'reactstrap';

export default class Register extends React.Component {

    render() {

        return (
            <div>

                <Container>
                    <h2>Sign In</h2>
                    <Form>
                        <Col>
                            <FormGroup>
                                <Label>Email</Label>
                                <Input
                                    type="email"
                                    name="email"
                                    id="exampleEmail"
                                    placeholder="myemail@email.com"
                                />
                            </FormGroup>
                        </Col>
                        <Col>
                            <FormGroup>
                                <Label for="PhoneNumber">Phone Number</Label>
                                <Input
                                    type="Phone Number"
                                    name="Phone Number"
                                    id="exampleNumber"
                                    placeholder="37060289225"
                                />
                            </FormGroup>
                        </Col>
                        <Col>
                            <FormGroup>
                                <Label for="RepeatPassword">Repeat Password</Label>
                                <Input
                                    type="Repeat Password"
                                    name="Repeat Password"
                                    id="RepeatPassword"
                                    placeholder="********"
                                />
                            </FormGroup>
                        </Col>
                        <Col>
                            <FormGroup>
                                <Label for="examplePassword">Password</Label>
                                <Input
                                    type="password"
                                    name="password"
                                    id="examplePassword"
                                    placeholder="********"
                                />
                            </FormGroup>
                        </Col>

                        <Button>Submit</Button>
                    </Form>
                </Container>
            </div>
        );
    }
}
Register.id = "app";