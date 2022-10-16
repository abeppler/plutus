import { useState } from "react";
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
  Col
} from "reactstrap";

// core components
import {
  chartOptions,
  parseOptions,
  chartExample1,
  chartExample2
} from "variables/charts.js";

import Header from "components/Headers/Header.js";

const Index = (props) => {
  const [activeNav, setActiveNav] = useState(1);
  const [chartExample1Data, setChartExample1Data] = useState("data1");

  if (window.Chart) {
    parseOptions(Chart, chartOptions());
  }

  const toggleNavs = (e, index) => {
    e.preventDefault();
    setActiveNav(index);
    setChartExample1Data("data" + index);
  };
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
                    <th scope="col">Tipo</th>
                    <th scope="col">Conta</th>
                    <th scope="col">Grupo Conta</th>
                    <th scope="col">Histórico</th>
                    <th scope="col">Data</th>
                    <th scope="col">Valor</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <th>Despesa</th>
                    <td>Nubank Anderson</td>
                    <td>Streamings</td>
                    <td>Netflix</td>
                    <td>06/10/2022</td>
                    <td>R$ 55,90</td>
                  </tr>
                  <tr>
                    <th>Despesa</th>
                    <td>Nubank Anderson</td>
                    <td>Streamings</td>
                    <td>Amazon</td>
                    <td>06/10/2022</td>
                    <td>R$ 10,00</td>
                  </tr>                  
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
