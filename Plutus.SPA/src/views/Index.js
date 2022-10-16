import { useState, useEffect } from "react";

import axios from "axios";

// node.js library that concatenates classes (strings)
import classnames from "classnames";
// javascipt plugin for creating charts
import Chart from "chart.js";
// react plugin used to create charts
import { Line, Bar } from "react-chartjs-2";
// reactstrap components
import {
  Button,
  Card,
  CardHeader,
  CardBody,
  NavItem,
  NavLink,
  Nav,
  Progress,
  Table,
  Container,
  Row,
  Col,
} from "reactstrap";

// core components
import {
  chartOptions,
  parseOptions,
  chartExample1,
  chartExample2,
} from "variables/charts.js";

import Header from "components/Headers/Header.js";

const Index = (props) => {
  const [activeNav, setActiveNav] = useState(1);
  const [chartExample1Data, setChartExample1Data] = useState("data1");

  const [lancamentos, setLancamentos] = useState([]);

  useEffect(() => {
    axios.get("https://localhost:7207/Lancamento").then((response) => {
      setLancamentos(response.data);
    });
  }, []);

  if (window.Chart) {
    parseOptions(Chart, chartOptions());
  }

  const toggleNavs = (e, index) => {
    e.preventDefault();
    setActiveNav(index);
    setChartExample1Data("data" + index);
  };

  const tableConfig = [
    { name: "Tipo", colValue: "tipoLancamentoDescricao" },
    { name: "Conta", colValue: "contaDescricao" },
    { name: "Grupo Conta", colValue: "grupoContaDescricao" },
    { name: "Histórico", colValue: "historico" },
    { name: "Data", colValue: "dataFormatada" },
    { name: "Valor", colValue: "valorFormatado" },
  ];

  return (
    <>
      <Header />
      {/* Page content */}
      <Container className="mt--7" fluid>
        <Row className="mt-5">
          <Col className="mb-12 mb-xl-0" xl="12">
            <Card className="shadow">
              <CardHeader className="border-0">
                <Row className="align-items-center">
                  <div className="col">
                    <h3 className="mb-0">Lançamentos</h3>
                  </div>
                  <div className="col text-right">
                    <Button
                      color="primary"
                      onClick={(e) => e.preventDefault()}
                      size="sm"
                    >
                      Novo
                    </Button>
                  </div>
                </Row>
              </CardHeader>
              <Table className="align-items-center table-flush" responsive>
                <thead className="thead-light">
                  <tr>
                    {tableConfig.map((col) => <th key={col.name} scope="col">{col.name}</th>)}
                  </tr>
                </thead>
                <tbody>
                  {lancamentos.map((rowValue) => <tr key={rowValue.id}>
                    {tableConfig.map((col) => <td key={col.name} scope="col">{rowValue[col.colValue]}</td>)}
                  </tr>)}                  
                </tbody>
              </Table>
            </Card>
          </Col>
        </Row>
      </Container>
    </>
  );
};

export default Index;
