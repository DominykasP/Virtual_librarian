import React from "react";
import { render } from "react-dom";
import { makeData, Logo, Tips } from "./Utils";
import axios from 'axios';



import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import classNames from 'classnames';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Tooltip from '@material-ui/core/Tooltip';

import FilterListIcon from '@material-ui/icons/FilterList';
import Paper from '@material-ui/core/Paper';

import IconButton from '@material-ui/core/IconButton';

import TablePagination from '@material-ui/core/TablePagination';
import { lighten } from '@material-ui/core/styles/colorManipulator';
import blue from '@material-ui/core/colors/blue';
import deepPurple from '@material-ui/core/colors/deepPurple';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';

import { withTheme } from '@material-ui/core/styles';

// Import React Table
import ReactTable from "react-table";
import "react-table/react-table.css";
import "./LibraryStyling.css"

const theme1 = createMuiTheme({
    palette: {
        type: 'dark', // Switching the dark mode on is a single property value change.
    },
    typography: { useNextVariants: true },
});

const toolbarStyles = createMuiTheme => ({
    root: {
        paddingRight: createMuiTheme.spacing.unit,
    },
    highlight:
        createMuiTheme.palette.type === 'dark'
            ? {
                color: createMuiTheme.palette.secondary.main,
                backgroundColor: lighten(createMuiTheme.palette.secondary.light, 0.85),
            }
            : {
                color: createMuiTheme.palette.text.primary,
                backgroundColor: createMuiTheme.palette.secondary.dark,
            },
    spacer: {
        flex: '1 1 100%',
    },
    actions: {
        color: createMuiTheme.palette.text.secondary,
    },
    title: {
        flex: '0 0 auto',
        palette: {
            primary: blue,
        },
        typography: {
            useNextVariants: true,
        },
    },

});



let EnhancedTableToolbar = props => {
    const { numSelected, classes } = props;
    const state = createMuiTheme({
        palette: {
            primary: deepPurple,
            secondary: {
                main: '#f44336',
            },
        },
    });

    return (
        <Toolbar
            className={classNames(classes.root, {
                [classes.highlight]: numSelected > 0,
            })}
            >
        <div className={classes.title}>
                {numSelected > 0 ? (
                <Typography className={classes.title} color="inherit" variant="subtitle1">
                        {numSelected} selected
                </Typography>
           ) : (
                <Typography variant="h5" id="tableTitle">
                    Mano knygos
                </Typography>
                )}
        </div>
            <div className={classes.spacer} />
            <div className={classes.actions}>
                {numSelected > 0 ? (
                    <Tooltip title="Delete">
                        <IconButton aria-label="Delete">
                            <DeleteIcon />
                        </IconButton>
                    </Tooltip>
                ) : (
                        <Tooltip title="Filter list">
                            <IconButton aria-label="Filter list">
                                <FilterListIcon />
                            </IconButton>
                        </Tooltip>
                    )}
            </div>
        </Toolbar>
    );
};
EnhancedTableToolbar.propTypes = {
    theme: PropTypes.object.isRequired,
};
withTheme()(EnhancedTableToolbar);
EnhancedTableToolbar = withStyles(toolbarStyles)(EnhancedTableToolbar);

const styles5 = theme => ({
    root: {
        width: '90%',
        marginTop: theme.spacing.unit * 3,
        overflowX: 'auto',
        marginLeft: 65,
    },
    table: {
        minWidth: 700,
    },
    tableWrapper: {
        overflowX: 'auto',
    },
    rootHeader: {
        flexGrow: 1,
    },
    growHeader: {
        flexGrow: 1,
    },
    menuButtonHeader: {
        marginLeft: -12,
        marginRight: 20,
    },
});

class LibraryBooks extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            allReaderBooks: [],
            page: 0,
            rowsPerPage: 5,
        };
    }

    componentDidMount() {
        let xmls =
            '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">\
            <soap:Body>\
                <GetReadersBooks xmlns="api/BookService">\
                    <readerId>' + localStorage.getItem('userId') + '</readerId>\
                </GetReadersBooks>\
            </soap:Body>\
            </soap:Envelope>';

        axios.post('http://localhost:52312/BookService.asmx?wsdl',
            xmls,
            {
                headers:
                {
                    'Content-Type': 'text/xml',
                    SOAPAction: 'api/BookService/GetReadersBooks'
                }
            }).then(response => {

                var XMLParser = require('react-xml-parser');
                var InXML = new XMLParser().parseFromString(response.data);
                var readerBooksInXML = InXML.getElementsByTagName('Book');

                var readerBooksWithProperties = [];
                var oneBook;

                for (var i = 0; i < readerBooksInXML.length; i++) {
                    oneBook = {};
                    oneBook.id = readerBooksInXML[i].children[0].value;
                    oneBook.name = readerBooksInXML[i].children[1].value;
                    oneBook.author = readerBooksInXML[i].children[2].value;
                    oneBook.publisher = readerBooksInXML[i].children[3].value;
                    oneBook.year = readerBooksInXML[i].children[4].value;
                    oneBook.pages = readerBooksInXML[i].children[5].value;
                    oneBook.isbn = readerBooksInXML[i].children[6].value;
                    oneBook.code = readerBooksInXML[i].children[7].value;

                    //console.log(oneBook);
                    readerBooksWithProperties.push(oneBook);
                }

                //console.log(readerBooksWithProperties);

                this.setState({
                    allReaderBooks: readerBooksWithProperties
                });
            }).catch(err => {
                console.log("Neįmanoma užkrauti skaitytojo knygų sąrašo");
            });
    };
    handleChangePage = (event, page) => {
        this.setState({ page });
    };

    handleChangeRowsPerPage = event => {
        this.setState({ rowsPerPage: event.target.value });
    };

    render() {
        const { classes } = this.props;
        const { data, order, orderBy, selected } = this.state;
      

        return (
            <div className="outside1">
             
              
                 <Paper className={classes.root}>
                    <EnhancedTableToolbar />
                    <div className={classes.tableWrapper}>
                        <Table className={classes.table}>
                            <TableHead>

                                <TableRow>
                                    <TableCell>Pavadinimas</TableCell>
                                    <TableCell>Autorius</TableCell>
                                    <TableCell>Leidejas</TableCell>
                                    <TableCell>Isleidimo metai</TableCell>
                                    <TableCell numeric>Puslapių skaičius</TableCell>
                                    <TableCell>ISBN</TableCell>
                                    <TableCell>Kodas</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {this.state.allReaderBooks.slice(this.state.page * this.state.rowsPerPage, this.state.page * this.state.rowsPerPage + this.state.rowsPerPage).map(row => {
                                    return (
                                        <TableRow key={row.id}>
                                            <TableCell component="th" scope="row">
                                                {row.name}
                                            </TableCell>
                                            <TableCell numeric>{row.author}</TableCell>
                                            <TableCell numeric>{row.publisher}</TableCell>
                                            <TableCell numeric>{row.year}</TableCell>
                                            <TableCell numeric>{row.pages}</TableCell>
                                            <TableCell numeric>{row.isbn}</TableCell>
                                            <TableCell numeric>{row.code}</TableCell>

                                        </TableRow>
                                    );
                                })}
                            </TableBody>
                        </Table>
                    </div>
                   <TablePagination
                        rowsPerPageOptions={[5, 10, 25]}
                        component="div"
                        count={this.state.allReaderBooks.length}
                        rowsPerPage={this.state.rowsPerPage}
                        page={this.state.page}
                        backIconButtonProps={{
                            'aria-label': 'Previous Page',
                        }}
                        nextIconButtonProps={{
                            'aria-label': 'Next Page',
                        }}
                        onChangePage={this.handleChangePage}
                        onChangeRowsPerPage={this.handleChangeRowsPerPage}
                    />
                </Paper>
            </div>
        );
    }
}
export default withStyles(styles5)(LibraryBooks);