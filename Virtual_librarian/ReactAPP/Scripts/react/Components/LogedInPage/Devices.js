import React from "react"
import "./margins.css"
export default class Devices extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isGoing: true,
            numberOfGuests: 2
        };

        this.handleInputChange = this.handleInputChange.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }
    render() {

        return (
            <div className="outside">
            <h1>Kazkas</h1>
                <form>
                    <label>
                        Is going:
          <input
                            name="IsGoing"
                            type="checkbox"
                            checked={this.state.isGoing}
                            onChange={this.handleInputChange} />
                    </label>
                    <br />
                    <label>
                        Number of guests:
          <input
                            name="numberOfGuests"
                            type="number"
                            value={this.state.numberOfGuests}
                            onChange={this.handleInputChange} />
                    </label>
                </form>
                </div>
        );
    }
}
Devices.id = "app";